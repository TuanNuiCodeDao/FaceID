using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceID
{
    public partial class F_Chinh : Form
    {
        public F_Chinh()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F_ThemSinhVien f=new F_ThemSinhVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_QLSinhVien f = new F_QLSinhVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_DiemDanh f = new F_DiemDanh();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            F_BaoCaoDiemDanh f = new F_BaoCaoDiemDanh();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
