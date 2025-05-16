using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class HDLaoDong
    {
        public int IdHopDong { get; set; }
        public string SoHD { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc {  get; set; }
        public DateTime NgayKy{ get; set; }
        public string NoiDung { get; set; }
        public int LanKy {  get; set; }
        public string ThoiHan {  get; set; }
        public float HeSoLuong { get; set; }

        public int LuongCoBan { get; set; }
        public int IdNhanVien { get; set; }
        public string HoTen { get; set; }
       
        public string CanCuocCongDan { get; set; }
        public string DiaChi { get; set; }
        public string NgaySinh { get; set; }



        public int? Created_By { get; set; } 
        public DateTime? Created_Date { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        

        public HDLaoDong() { }
        public HDLaoDong (int idHopDong, string soHD,DateTime ngayBatDau, DateTime ngayKetThuc, DateTime ngayKy, string hotenNhanVien, string cccd, string diachi,string ngaysinh,
        string noiDung, int lanKy, string thoiHan,int luongcoban, float heSoLuong, int idNhanVien, int? createdBy = null, DateTime? createdDate = null, int? updatedBy = null, DateTime? updatedDate = null
                        )
        {
            this.IdHopDong = idHopDong;
            this.SoHD = soHD;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
            this.NgayKy = ngayKy;
            this.NoiDung = noiDung;
            this.LanKy = lanKy;
            this.ThoiHan = thoiHan;
            this.HeSoLuong = heSoLuong;
            this.IdNhanVien = idNhanVien;
            this.HoTen = hotenNhanVien;
            this.CanCuocCongDan = cccd;
            this.DiaChi = diachi;
            this.LuongCoBan= luongcoban;
            this.NgaySinh = ngaysinh;
            this.Created_By = createdBy;
            this.Created_Date = createdDate;
            this.Updated_By = updatedBy;
            this.Updated_Date = updatedDate;
            
        }
    }
}
