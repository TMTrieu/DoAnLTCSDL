using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class TaiKhoanNhanVienBL
    {
        private TaiKhoanNhanVienDL taiKhoanNhanVienDL = new TaiKhoanNhanVienDL();

        public int LayMaTaiKhoan(string tenDangNhap)
        {
            return taiKhoanNhanVienDL.GetMaTaiKhoanByUsername(tenDangNhap);
        }

        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            return taiKhoanNhanVienDL.DangNhap(tenDangNhap, matKhau);
        }

        public bool KiemTraTaiKhoanTonTai(string tenDangNhap)
        {
            return taiKhoanNhanVienDL.KiemTraTaiKhoan(tenDangNhap);
        }


        public string LayMatKhau(string tenDangNhap)
        {
            return taiKhoanNhanVienDL.LayMatKhau(tenDangNhap);
        }
        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            return taiKhoanNhanVienDL.DoiMatKhau(tenDangNhap, matKhauCu, matKhauMoi);
        }

    }
}
