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
    public partial class F_ThongBaoLoi : Form
    {
        public F_ThongBaoLoi(string thongBao)
        {
            InitializeComponent();
            tbLoi.Text = thongBao;
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
