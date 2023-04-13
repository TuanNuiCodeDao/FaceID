using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceID.DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;
        public static DangNhapDAO Instance
        {
            get { if (instance == null) instance = new DangNhapDAO(); return instance; }
            private set { instance = value; }
        }
        private DangNhapDAO() { }
        public bool checkDangNhap(string tenTaiKhoan,string matKhau)
        {
            return DataProvider.Instance.RunQuery("SELECT *  FROM DangNhap WHERE TaiKhoan=N'"+tenTaiKhoan+"' AND MatKhau=N'"+matKhau+"'").Rows.Count > 0;
        }
    }
}
