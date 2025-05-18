using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TangCa
    {
        public int IdTangCa { get; set; }
        public DateTime NgayTangCa{ get; set; }
        public double SoGio { get; set; }
        public double SoTien { get; set; }
        public int IdNhanVien { get; set; }
        public string HoTen { get; set; }
        public int IdLoaiCa { get; set; }
        public string TenLoaiCa { get; set; }
        public double HeSo { get; set; }
        public string GhiChu { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        public int? Deleted_By { get; set; }
        public DateTime? Deleted_Date { get; set; }
        public TangCa() { }


        public TangCa(int id, DateTime ngayTangCa, double soGio, double soTien,int idNhanVien, string hoten,int idLoaiCa, string tenLoaiCa, double heSo, string ghichu, int? createdBy = null, DateTime? createdDate = null, int? updatedBy = null, DateTime? updatedDate = null,
                         int? deletedBy = null, DateTime? deletedDate = null)
        {
            this.IdTangCa = id;
            this.SoGio = soGio;
            this.SoTien = soTien;
            this.IdNhanVien= idNhanVien;
            this.HoTen=hoten;
            this.IdLoaiCa= idLoaiCa;  
            this.TenLoaiCa= tenLoaiCa;
            this.HeSo= heSo;
            this.GhiChu = ghichu;
            this.Created_By = createdBy;
            this.Created_Date = createdDate;
            this.Updated_By = updatedBy;
            this.Updated_Date = updatedDate;
            this.Deleted_By = deletedBy;
            this.Deleted_Date = deletedDate;
        }
    }
}
