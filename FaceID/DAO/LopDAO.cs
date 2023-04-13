using FaceID.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DAO
{
    public class LopDAO
    {
        private static LopDAO instance;
        public static LopDAO Instance
        {
            get { if (instance == null) instance = new LopDAO(); return instance; }
            private set { instance = value; }
        }
        private LopDAO() { }
        public List<Lop> loadDS()
        {
            List<Lop> l = new List<Lop>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Lop");
            foreach (DataRow item in d.Rows)
            {
                Lop i = new Lop(item);
                l.Add(i);
            }
            return l;
        }
        public List<Lop> loadDSBMaKhoa(string maKhoa)
        {
            List<Lop> l = new List<Lop>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Lop WHERE MaKhoa=N'"+ maKhoa + "'");
            foreach (DataRow item in d.Rows)
            {
                Lop i = new Lop(item);
                l.Add(i);
            }
            return l;
        }
        public Lop getByTen(string ten)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Lop WHERE TenLop=N'" + ten + "'");
            foreach (DataRow item in d.Rows)
            {
                Lop i = new Lop(item);
                return i;
            }
            return null;
        }
        public Lop getByMa(string ma)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM Lop WHERE MaLop=N'" + ma + "'");
            foreach (DataRow item in d.Rows)
            {
                Lop i = new Lop(item);
                return i;
            }
            return null;
        }
    }
}
