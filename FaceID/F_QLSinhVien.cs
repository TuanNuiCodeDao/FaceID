using FaceID.DAO;
using FaceID.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceID
{
    public partial class F_QLSinhVien : Form
    {
        public F_QLSinhVien()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            loadCbKhoa();
            loadDS();
        }
        private void loadDS()
        {
            dgvSinhVien.Rows.Clear();
            List<SinhVien> l = SinhVienDAO.Instance.loadDS();
            foreach(SinhVien i in l)
            {
                Lop lop = LopDAO.Instance.getByMa(i.MaLop);
                Khoa k = KhoaDAO.Instance.getByMa(lop.MaKhoa);
                dgvSinhVien.Rows.Add(i.HoTen, i.MaSV, k.TenKhoa, lop.TenLop);
            }    
        }
        private void loadCbKhoa()
        {
            cbKhoa.Items.Clear();
            List<Khoa> l = KhoaDAO.Instance.loadDS();
            foreach (Khoa i in l)
            {
                cbKhoa.Items.Add(i.TenKhoa);
            }
            if (cbKhoa.Items.Count > 0)
                cbKhoa.Text = cbKhoa.Items[0].ToString();
        }
        private void loadCbLop()
        {
            cbLop.Items.Clear();
            Khoa k = KhoaDAO.Instance.getByTen(cbKhoa.Text);
            if (k == null)
                return;
            List<Lop> l = LopDAO.Instance.loadDSBMaKhoa(k.MaKhoa);
            foreach (Lop i in l)
            {
                cbLop.Items.Add(i.TenLop);
            }
            if (cbLop.Items.Count > 0)
                cbLop.Text = cbLop.Items[0].ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCbLop();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvSinhVien.Rows[e.RowIndex];
                tbMSSV.Text = Convert.ToString(row.Cells[1].Value);
                SinhVien i=SinhVienDAO.Instance.getByMa(tbMSSV.Text);
                if (i == null)
                    return;
                tbTenSV.Text = i.HoTen;
                Lop l=LopDAO.Instance.getByMa(i.MaLop);
                cbLop.Text = l.TenLop;
                Khoa k = KhoaDAO.Instance.getByMa(l.MaKhoa);
                cbKhoa.Text = k.TenKhoa;
                ptFace.Image = Image.FromFile(i.UrlAnh);
            }
            catch (Exception)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinhVien i = SinhVienDAO.Instance.getByMa(tbMSSV.Text);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn sinh viên cần xóa !");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa sinh viên N'"+i.HoTen+"' ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                ptFace.Image = null;
                SinhVienDAO.Instance.xoa(i.MaSV);
                loadDS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SinhVien i = SinhVienDAO.Instance.getByMa(tbMSSV.Text);
            if (i == null)
            {
                MessageBox.Show("Hãy chọn sinh viên cần sửa !");
                return;
            }
            if (string.IsNullOrEmpty(tbTenSV.Text))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống !");
                return;
            }
            SinhVienDAO.Instance.sua(new SinhVien(i.MaSV,LopDAO.Instance.getByTen(cbLop.Text).MaLop, tbTenSV.Text, i.UrlAnh));
            loadDS();
            MessageBox.Show("Cập nhật thông tin sinh viên thành công !", "Thông báo");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
