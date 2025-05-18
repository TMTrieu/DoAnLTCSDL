using PresentationLayer.ChamCong;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FormBangLuong());

            FormDangNhap frmDangNhap = new FormDangNhap();
            DialogResult result = frmDangNhap.ShowDialog();

            if (result == DialogResult.OK)
            {
                string vaiTro = frmDangNhap.VaiTro.ToLower();

                if (vaiTro == "admin")
                {
                    Application.Run(new FormAdmin());
                }
                else
                {
                    //int idNV = frmDangNhap.IdNhanVien;
                    Application.Run(new FormUser(frmDangNhap.IdNhanVien));
                }
            }
        }
    }
}
