using FaceID.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DAO
{
    public class KhoaDAO
    {
        private static KhoaDAO instance;
        public static KhoaDAO Instance
        {
            get { if (instance == null) instance = new KhoaDAO(); return instance; }
            private set { instance = value; }
        }
        private KhoaDAO() { }
        public List<Khoa> loadDS()
        {
            List<Khoa> l = new List<Khoa>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Khoa");
            foreach (DataRow item in d.Rows)
            {
                Khoa i = new Khoa(item);
                l.Add(i);
            }
            return l;
        }
        public Khoa getByTen(string ten)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Khoa WHERE TenKhoa=N'" + ten + "'");
            foreach (DataRow item in d.Rows)
            {
                Khoa i = new Khoa(item);
                return i;
            }
            return null;
        }
        public Khoa getByMa(string ma)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Khoa WHERE MaKhoa=N'" + ma + "'");
            foreach (DataRow item in d.Rows)
            {
                Khoa i = new Khoa(item);
                return i;
            }
            return null;
        }
    }
}
