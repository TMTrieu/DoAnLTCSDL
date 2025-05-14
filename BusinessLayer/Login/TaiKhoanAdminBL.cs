using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class TaiKhoanAdminBL
    {
        private TaiKhoanAdminDL taiKhoanDL = new TaiKhoanAdminDL();

        public int LayMaTaiKhoan(string tenDangNhap)
        {
            return taiKhoanDL.GetMaTaiKhoanByUsername(tenDangNhap);
        }

        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            return taiKhoanDL.DangNhap(tenDangNhap, matKhau);
        }

        public bool KiemTraTaiKhoanTonTai(string tenDangNhap)
        {
            return taiKhoanDL.KiemTraTaiKhoan(tenDangNhap);
        }

       

        public string LayMatKhau(string tenDangNhap)
        {
            return taiKhoanDL.LayMatKhau(tenDangNhap);
        }

       


    }

}
