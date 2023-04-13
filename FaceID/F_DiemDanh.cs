using AForge.Video;
using AForge.Video.DirectShow;
using FaceID.DAO;
using FaceID.DTO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
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

namespace FaceID
{
    public partial class F_DiemDanh : Form
    {
        private VideoCaptureDevice m_videoSource;
        private Bitmap g_bmp;
        private Bitmap bmp;
        private float g_scaleX = 1;
        private float g_scaleY = 1;
        private Image khuonMat;
        public F_DiemDanh()
        {
            InitializeComponent();
            loadDS();
            btDiemDanh.Enabled = false;
            btXacNhan.Enabled = false;
            khuonMat = null;
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
        private void loadDS()
        {
            dgvDiemDanh.Rows.Clear();
            DateTime thoiGian = DateTime.Now;
            List<DiemDanh> l = DiemDanhDAO.Instance.loadDSByDieuKien("SELECT* FROM DiemDanh WHERE YEAR(ThoiGian)="
                + thoiGian.Year + " AND MONTH(ThoiGian)=" + thoiGian.Month + " AND DAY(ThoiGian)=" + thoiGian.Day);
            foreach (DiemDanh i in l)
            {
                SinhVien iSV = SinhVienDAO.Instance.getByMa(i.MaSV);
                Lop iL = LopDAO.Instance.getByMa(iSV.MaLop);
                Khoa iK = KhoaDAO.Instance.getByMa(iL.MaKhoa);
                dgvDiemDanh.Rows.Add(iSV.HoTen, iSV.MaSV, i.ThoiGian.ToString("dd/MM/yyyy HH:mm"),  iK.TenKhoa, iL.TenLop);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool trichXuatKhuonMat()
        {
            try
            {
                var cascade = new CascadeClassifier(@"haarcascade_frontalface_alt.xml");
                var color = Scalar.FromRgb(0, 255, 0);
                var srcImage = bmp.ToMat();
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
                        khuonMat = faceMat.ToBitmap();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                F_ThongBaoLoi f = new F_ThongBaoLoi("Trích xuất khuôn mặt thất bại:\n" + ex.ToString());
            }
            return false;
        }

        public int FindMostSimilarImageIndex(Image face, List<Image> lFace)
        {
            double minDistance = double.MaxValue;
            int mostSimilarIndex = -1;

            for (int i = 0; i < lFace.Count; i++)
            {
                double distance = CalculateImageDistance(face, lFace[i]);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    mostSimilarIndex = i;
                }
            }

            return mostSimilarIndex;
        }

        private double CalculateImageDistance(Image img1, Image img2)
        {
            Bitmap bitmap1 = new Bitmap(img1);
            Bitmap bitmap2 = new Bitmap(img2);

            int width = Math.Min(bitmap1.Width, bitmap2.Width);
            int height = Math.Min(bitmap1.Height, bitmap2.Height);

            double distance = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel1 = bitmap1.GetPixel(x, y);
                    Color pixel2 = bitmap2.GetPixel(x, y);
                    int redDiff = pixel1.R - pixel2.R;
                    int greenDiff = pixel1.G - pixel2.G;
                    int blueDiff = pixel1.B - pixel2.B;

                    double pixelDistance = Math.Sqrt(redDiff * redDiff + greenDiff * greenDiff + blueDiff * blueDiff);

                    distance += pixelDistance;
                }
            }

            distance /= width * height;

            return distance;
        }
        private void batDauDiemDanh()
        {
            bool kq=trichXuatKhuonMat();
            if(kq==false)
            {
                btXacNhan.Enabled = false;
                return;
            }
            try
            {
                List<string> imagePaths = new List<string>();
                List<SinhVien> l = SinhVienDAO.Instance.loadDS();
                foreach (SinhVien i in l)
                {
                    string duongDan = @"C:\DataFaceID\" + i.MaSV + ".jpg";
                    imagePaths.Add(duongDan);
                }
                List<Image> faceImages = new List<Image>();
                foreach (string duongDan in imagePaths)
                {
                    Image i = Image.FromFile(duongDan);
                    faceImages.Add(i);
                }
                int output = FindMostSimilarImageIndex(khuonMat, faceImages);
                if(output == -1)
                {
                    tbMSSV.Text = "";
                    tbTenSV.Text = "";
                    btXacNhan.Enabled = false;
                    return;
                }    
                string maSV = Path.GetFileNameWithoutExtension(imagePaths[output]);
                SinhVien sv = SinhVienDAO.Instance.getByMa(maSV);
                tbMSSV.Text = sv.MaSV;
                tbTenSV.Text = sv.HoTen;
                btXacNhan.Enabled = true;
            }
            catch(Exception ex)
            {
                F_ThongBaoLoi f = new F_ThongBaoLoi(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_videoSource.IsRunning)
            {
                bmp = (Bitmap)g_bmp.Clone();
                m_videoSource.Stop();
                btDiemDanh.Enabled = true;
                btBuoc1.Text = "Mở lại Webcam";
                return;
            }
            else
            {
                m_videoSource.Start();
                btDiemDanh.Enabled = false;
                btXacNhan.Enabled = false;
                khuonMat = null;
                btBuoc1.Text = "1. Bắt đầu quá trình điểm danh";
                tbMSSV.Text = "";
                tbTenSV.Text = "";
            }
        }

        private void btBuoc2_Click(object sender, EventArgs e)
        {
            batDauDiemDanh();
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            if(SinhVienDAO.Instance.getByMa(tbMSSV.Text)==null)
            {
                MessageBox.Show("Chưa nhận diện được sinh viên !");
                return;
            }
            if (DiemDanhDAO.Instance.loadByMaSV_ThoiGian(tbMSSV.Text,DateTime.Now)!=null)
            {
                MessageBox.Show("Hôm nay, sinh viên này đã được điểm danh !");
                return;
            }
            DiemDanhDAO.Instance.them(tbMSSV.Text);
            loadDS();
            MessageBox.Show("Điểm danh thành công !");
        }

        private void F_DiemDanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_videoSource.Stop();
        }
    }
}
