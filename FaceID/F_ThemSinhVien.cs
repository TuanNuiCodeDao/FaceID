using FaceID.DAO;
using FaceID.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using AForge.Video.DirectShow;
using AForge.Video;
namespace FaceID
{
    public partial class F_ThemSinhVien : Form
    {
        private VideoCaptureDevice m_videoSource;
        private Bitmap g_bmp;
        private Bitmap bmp;
        private float g_scaleX = 1;
        private float g_scaleY = 1;
        public F_ThemSinhVien()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            loadCbKhoa();
            btBuoc2.Enabled = false;
            btBuoc3.Enabled = false;
            loadWebCam();
        }
        private void loadWebCam()
        {
            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            m_videoSource = new VideoCaptureDevice(videosources[0].MonikerString);
            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();
        }
        private void OnCameraFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (g_bmp != null)
                g_bmp.Dispose();

            g_scaleX = (float)eventArgs.Frame.Width / ptAnhGoc.Width;
            g_scaleY = (float)eventArgs.Frame.Height / ptAnhGoc.Height;

            g_bmp = (Bitmap)eventArgs.Frame.Clone();
            ptAnhGoc.Image = g_bmp;
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

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCbLop();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbHoTen.Text))
            {
                MessageBox.Show("Họ tên sinh viên không được để trống !");
                return;
            }
            if (DataProvider.Instance.checkMSSV(tbMSSV.Text) == false)
            {
                MessageBox.Show("Mã sinh viên phải là 1 chuỗi ký tự số và độ dài lớn hơn 4 !");
                return;
            }
            if (SinhVienDAO.Instance.getByMa(tbMSSV.Text) != null)
            {
                MessageBox.Show("Mã sinh viên đã được sử dụng cho sinh viên khác !");
                return;
            }
            string duongDan = @"C:\DataFaceID\" + tbMSSV.Text + ".JPG";
            if(File.Exists(duongDan))
                File.Delete(duongDan);  
            ptKhuonMat.Image.Save(duongDan);
            SinhVienDAO.Instance.them(new SinhVien(tbMSSV.Text, LopDAO.Instance.getByTen(cbLop.Text).MaLop, tbHoTen.Text, duongDan));
            MessageBox.Show("Thêm sinh viên mới thành công !", "Thông báo");
            btBuoc2.Enabled = false;
            btBuoc3.Enabled = false;
        }
        private void btBuoc1_Click(object sender, EventArgs e)
        {
            if(m_videoSource.IsRunning)
            {
                bmp = (Bitmap)g_bmp.Clone();
                m_videoSource.Stop();
                btBuoc2.Enabled = true;
                btBuoc1.Text = "Mở lại Webcam";
                return;
            }    
            else
            {
                m_videoSource.Start();
                btBuoc2.Enabled = false;
                btBuoc3.Enabled = false;
                ptKhuonMat.Image = null;
                btBuoc1.Text = "1. Nhận diện khuôn mặt";
            } 
        }

        private void btBuoc2_Click(object sender, EventArgs e)
        {
            try
            {
                var cascade = new CascadeClassifier(@"haarcascade_frontalface_alt.xml");
                var color = Scalar.FromRgb(0, 255, 0);
                var srcImage =bmp.ToMat();
                using (var grayImage = new Mat())
                {
                    Cv2.CvtColor(srcImage, grayImage, ColorConversionCodes.BGRA2GRAY);
                    Cv2.EqualizeHist(grayImage, grayImage);

                    var faces = cascade.DetectMultiScale(
                        image: grayImage,
                        minSize: new OpenCvSharp.Size(90, 90)
                        );

                    foreach (var faceRect in faces)
                    {
                        var faceMat = new Mat(srcImage, faceRect);
                        ptKhuonMat.Image = faceMat.ToBitmap();
                        btBuoc3.Enabled = true;
                        return;
                    }
                    ptKhuonMat.Image = null;
                }
            }
            catch (Exception ex)
            {
                F_ThongBaoLoi f = new F_ThongBaoLoi("Trích xuất khuôn mặt thất bại:\n"+ex.ToString());
            }
            
        }

        private void F_ThemSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_videoSource.Stop();
        }
    }
}
