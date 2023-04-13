using FaceID.DAO;
using FaceID.DTO;
using OpenCvSharp.ImgHash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Font = iTextSharp.text.Font;

namespace FaceID
{
    public partial class F_BaoCaoDiemDanh : Form
    {
        public F_BaoCaoDiemDanh()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            loadCbKhoa();
            
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
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbKhoa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loadCbLop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvDiemDanh.Rows.Clear();
            DateTime thoiGian = (DateTime)dateTG.Value;
            string dieuKien = " YEAR(ThoiGian)="
                + thoiGian.Year + " AND MONTH(ThoiGian)=" + thoiGian.Month + " AND DAY(ThoiGian)=" + thoiGian.Day;
            List<DiemDanh> l = new List<DiemDanh>();
            if(checkLoc.Checked)
            {
                if(checkLop.Checked)
                {
                    Lop lop=LopDAO.Instance.getByTen(cbLop.Text);
                    if(lop==null) return;
                    l = DiemDanhDAO.Instance.loadDSByDieuKien("SELECT*FROM DiemDanh,SinhVien WHERE DiemDanh.MaSV=SinhVien.MaSV AND " +
                        "SinhVien.MaLop=N'" + lop.MaLop + "' AND " + dieuKien);
                }
                else
                {
                    if (checkKhoa.Checked)
                    {
                        Khoa k = KhoaDAO.Instance.getByTen(cbKhoa.Text);
                        if (k == null) return;
                        l = DiemDanhDAO.Instance.loadDSByDieuKien("SELECT*FROM DiemDanh,SinhVien,Lop WHERE DiemDanh.MaSV=SinhVien.MaSV AND " +
                            "Lop.MaKhoa=N'" + k.MaKhoa + "' AND Lop.MaLop=SinhVien.MaLop AND " + dieuKien);
                    }
                    else
                        l = DiemDanhDAO.Instance.loadDSByDieuKien("SELECT*FROM DiemDanh WHERE " + dieuKien);
                }
            }
            else
                l = DiemDanhDAO.Instance.loadDSByDieuKien("SELECT*FROM DiemDanh WHERE " + dieuKien);
            foreach(DiemDanh i in l)
            {
                SinhVien iSV = SinhVienDAO.Instance.getByMa(i.MaSV);
                Lop iL = LopDAO.Instance.getByMa(iSV.MaLop);
                Khoa iK = KhoaDAO.Instance.getByMa(iL.MaKhoa);
                dgvDiemDanh.Rows.Add(iSV.HoTen, iSV.MaSV,i.ThoiGian.ToString("dd/MM/yyyy HH:mm"), iK.TenKhoa, iL.TenLop);
            }    
        }

        private void checkKhoa_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string url ="";
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                url = f.SelectedPath;
            }
            else
            {
                url = "";
                return;
            }
            DateTime tg = (DateTime)dateTG.Value;
            string tenFile = "DiemDanhSinhVien_" + tg.Day + "_" + tg.Month + "_" + tg.Year + ".pdf";
            string duongDan = url + @"\" + tenFile;
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(doc, new FileStream(duongDan, FileMode.Create));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(baseFont, 12);
            PdfPTable pdfTable = new PdfPTable(dgvDiemDanh.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            foreach (DataGridViewColumn column in dgvDiemDanh.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            foreach (DataGridViewRow row in dgvDiemDanh.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value?.ToString(), font));
                }
            }
            doc.Add(pdfTable);
            doc.Close();
            MessageBox.Show("Xuất báo cáo thành công !\nFile pdf của bạn có đường dẫn là:\n" +
                        duongDan);
        }
    }
}
