using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TaiKhoan

    {
        public TaiKhoan() { }
       
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
      
        public bool IsDeleted { get; set; }
        public int IdNhanVien { get; set; }

        public TaiKhoan(string tenDangNhap,string matkhau,string vaitro,bool isDeleted, int idNhanVien)
        {
            
            TenDangNhap = tenDangNhap;
            MatKhau = matkhau;
            VaiTro = vaitro;
            IdNhanVien = idNhanVien;
            IsDeleted = isDeleted;
        }
    }
}
