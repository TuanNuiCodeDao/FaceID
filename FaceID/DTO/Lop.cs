using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DTO
{
    public class Lop
    {
        private string maLop;
        private string tenLop;
        private string maKhoa;

        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }

        public Lop() { }
        public Lop(string maLop, string maKhoa, string tenLop)
        {
            this.MaLop = maLop;
            this.TenLop = tenLop;
            this.MaKhoa = maKhoa;
        }
        public Lop(DataRow d)
        {
            MaLop = d["MaLop"].ToString();
            TenLop = d["TenLop"].ToString();
            MaKhoa = d["MaKhoa"].ToString();
        }
    }
}
