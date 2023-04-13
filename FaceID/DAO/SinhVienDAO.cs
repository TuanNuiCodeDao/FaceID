using FaceID.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DAO
{
    public class SinhVienDAO
    {
        private static SinhVienDAO instance;
        public static SinhVienDAO Instance
        {
            get { if (instance == null) instance = new SinhVienDAO(); return instance; }
            private set { instance = value; }
        }
        private SinhVienDAO() { }
        public List<SinhVien> loadDS()
        {
            List<SinhVien> l = new List<SinhVien>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM SinhVien");
            foreach (DataRow item in d.Rows)
            {
                SinhVien i = new SinhVien(item);
                l.Add(i);
            }
            return l;
        }
        public SinhVien getByMa(string ma)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM SinhVien WHERE MaSV=N'" + ma + "'");
            foreach (DataRow item in d.Rows)
            {
                SinhVien i = new SinhVien(item);
                return i;
            }
            return null;
        }
        public void them(SinhVien i)
        {
            DataProvider.Instance.RunQuery("INSERT INTO SinhVien(MaSV,MaLop,HoTen,UrlAnh) VALUES(N'" + i.MaSV + "',N'"+i.MaLop+"',N'" + i.HoTen + "',N'" + i.UrlAnh + "')");
        }
        public void xoa(string ma)
        {
            DataProvider.Instance.RunQuery("DELETE FROM DiemDanh WHERE MaSV = N'" + ma + "'");
            DataProvider.Instance.RunQuery("DELETE FROM SinhVien WHERE MaSV = N'" + ma + "'");
            
        }

        public void sua(SinhVien i)
        {
            DataProvider.Instance.RunQuery("UPDATE SinhVien SET MaLop=N'" + i.MaLop + "',HoTen=N'" + i.HoTen + "',UrlAnh=N'" + i.UrlAnh + "' WHERE MaSV=N'"+i.MaSV+"'");
        }
    }
}
