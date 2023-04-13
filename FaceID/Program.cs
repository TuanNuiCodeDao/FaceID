using System;
using System.IO;
using System.Windows.Forms;

namespace FaceID
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string path = @"C:\DataFaceID";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Application.Run(new F_DangNhap());
        }
        public static string g_parentDir = "";
    }
}
