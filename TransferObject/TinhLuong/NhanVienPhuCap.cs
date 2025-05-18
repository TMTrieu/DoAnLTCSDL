using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class NhanVienPhuCap
    {
        public int IdNhanVienPhuCap { get; set; }
        public int IdNhanVien { get; set; }
        public int IdPhuCap { get; set; }
        public string HoTen { get; set; }
        public string TenChucVu { get; set; }
        public DateTime Ngay { get; set; }
        public string NoiDung { get; set; }
        public double SoTien { get; set; }

        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        public int? Deleted_By { get; set; }
        public DateTime? Deleted_Date { get; set; }


        public string TenPhuCap { get; set; }

        public NhanVienPhuCap() { }
        public NhanVienPhuCap(int idNhanVienPhuCap , int idNhanVien,int idPhuCap,DateTime ngay, string hoten,string tenChucVu,string noidung, double soTien,string tenPC, int? createdBy = null, DateTime? createdDate = null, int? updatedBy = null, DateTime? updatedDate = null,
                         int? deletedBy = null, DateTime? deletedDate = null)
        {
            this.IdNhanVienPhuCap = idNhanVienPhuCap;
            this.IdNhanVien = idNhanVien;
            this.IdPhuCap = idPhuCap;
            this.HoTen=hoten;
            this.TenChucVu= tenChucVu;
            this.Ngay = ngay;
            this.NoiDung = noidung;
            this.TenPhuCap = tenPC;
            this.SoTien = soTien;
            this.Created_By = createdBy;
            this.Created_Date = createdDate;
            this.Updated_By = updatedBy;
            this.Updated_Date = updatedDate;
            this.Deleted_By = deletedBy;
            this.Deleted_Date = deletedDate;
        }
    }
}
