using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DTO
{
    public class Khoa
    {
        private string maKhoa;
        private string tenKhoa;
        public Khoa() { }
        public Khoa(string maKhoa,string tenKhoa)
        {
            this.MaKhoa = MaKhoa;
            this.TenKhoa = tenKhoa;
        }
        public Khoa(DataRow d)
        {
            TenKhoa = d["TenKhoa"].ToString() ;
            MaKhoa = d["MaKhoa"].ToString();
        }

        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
    }
}
