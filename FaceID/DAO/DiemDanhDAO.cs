using FaceID.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceID.DAO
{
    public class DiemDanhDAO
    {
        private static DiemDanhDAO instance;
        public static DiemDanhDAO Instance
        {
            get { if (instance == null) instance = new DiemDanhDAO(); return instance; }
            private set { instance = value; }
        }
        private DiemDanhDAO() { }
        public List<DiemDanh> loadDS()
        {
            List<DiemDanh> l = new List<DiemDanh>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DiemDanh");
            foreach (DataRow item in d.Rows)
            {
                DiemDanh i = new DiemDanh(item);
                l.Add(i);
            }
            return l;
        }
        public List<DiemDanh> loadDSByDieuKien(string truyVan)
        {
            List<DiemDanh> l = new List<DiemDanh>();
            DataTable d = DataProvider.Instance.RunQuery(truyVan);
            foreach (DataRow item in d.Rows)
            {
                DiemDanh i = new DiemDanh(item);
                l.Add(i);
            }
            return l;
        }
        public DiemDanh loadByMaSV_ThoiGian(string maSV,DateTime thoiGian)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DiemDanh WHERE MaSV=N'" + maSV + "' AND YEAR(ThoiGian)="
                +thoiGian.Year+" AND MONTH(ThoiGian)="+thoiGian.Month+" AND DAY(ThoiGian)="+thoiGian.Day);
            foreach (DataRow item in d.Rows)
            {
                DiemDanh i = new DiemDanh(item);
                return i;
            }
            return null;
        }
        public void them(string maSV)
        {
            DataProvider.Instance.RunQuery("INSERT INTO DiemDanh(MaSV) VALUES(N'" + maSV + "')");
        }
    }
}
