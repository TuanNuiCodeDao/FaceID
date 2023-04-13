using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FaceID.DTO
{
    public class SinhVien
    {
        private string maSV;
        private string hoTen;
        private string maLop;
        private string urlAnh;

        public string MaSV { get => maSV; set => maSV = value; }
        public string MaLop { get => maLop; set => maLop = value; }
        public string UrlAnh { get => urlAnh; set => urlAnh = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }

        public SinhVien()
        { }    
        public SinhVien(string maSV, string maLop, string hoTen, string urlAnh)
        {
            this.MaSV = maSV;
            this.MaLop = maLop;
            this.UrlAnh = urlAnh;
            this.HoTen = hoTen;
        }
        public SinhVien(DataRow d)
        {
            MaSV = d["MaSV"].ToString();
            MaLop = d["MaLop"].ToString();
            HoTen = d["HoTen"].ToString();
            UrlAnh = d["UrlAnh"].ToString();
        }
    }
}
