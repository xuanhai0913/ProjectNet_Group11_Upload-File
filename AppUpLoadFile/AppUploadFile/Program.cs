using System;
using System.Windows.Forms;

namespace UploadFilesToDrive
{
    internal static class Program
    {
        /// <summary>
        /// Điểm vào chính cho ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
