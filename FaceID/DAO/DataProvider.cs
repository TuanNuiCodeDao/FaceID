using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceID.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }
        private string connectionStr = "Data Source=DESKTOP-T6M1TMR\\MSSQLSERVER03;Initial Catalog=QuanLyDiemDanh;Integrated Security=True";
        private DataProvider()
        {

        }
        public string getDateSql(DateTime d)
        {
            string dSql = d.Year + "-" + d.Month + "-" + d.Day;
            return dSql;
        }
        public string getDinhDanhHangNghin(int i)
        {
            return String.Format("{0:###,###,##0}", i);
        }
        public bool checkMSSV(string s)
        {
            if (s.Length < 4)
                return false;
            for (int i = 0; i < s.Length; i++)
                if (s[i] > '9' || s[i] < '0')
                    return false;
            return true;
        }
        public DataTable RunQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                F_ThongBaoLoi f = new F_ThongBaoLoi(e.ToString());
            }
            return data;
        }
    }
}
