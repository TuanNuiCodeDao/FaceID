using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DTO
{
    public class DiemDanh
    {
        private string maSV;
        private DateTime thoiGian;

        public string MaSV { get => maSV; set => maSV = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }

        public DiemDanh() { }
        public DiemDanh(string maSV, DateTime thoiGian)
        {
            this.MaSV = maSV;
            this.ThoiGian = thoiGian;
        }
        public DiemDanh(DataRow d)
        {
            MaSV = d["MaSV"].ToString();
            ThoiGian = (DateTime)d["ThoiGian"];
        }
    }
}
