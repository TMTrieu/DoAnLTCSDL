using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject.TinhLuong
{
   public class BangLuong
    {
        public BangLuong() { }
        public int IdBangLuong { get; set; }
        public int MaKyCong {  get; set; }
        public int IdNhanVien { get; set; }
        public string HoTen {  get; set; }
        public int NgayCongTrongThang { get; set; }
        public double NgayPhep { get; set; }
        public double KhongPhep { get; set; }
        public double NgayLe {  get; set; }
        public double NgayChuNhat { get; set; }
        public double NgayThuong { get; set; }
        public double TangCa { get; set; }
        public double PhuCap { get; set; }
        public double ThucLanh { get; set; }

        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
        public int? Deleted_By { get; set; }
        public DateTime? Deleted_Date { get; set; }

        public BangLuong(int idBangLuong, int maKyCong, int idNhanVien, string hoTen, int ngayCongTrongThang, double ngayPhep, double khongPhep, double ngayLe, double ngayChuNhat, double ngayThuong, double tangCa, double phuCap, double thucLanh, int? created_By, DateTime? created_Date, int? updated_By, DateTime? updated_Date, int? deleted_By, DateTime? deleted_Date)
        {
            IdBangLuong = idBangLuong;
            MaKyCong = maKyCong;
            IdNhanVien = idNhanVien;
            HoTen = hoTen;
            NgayCongTrongThang = ngayCongTrongThang;
            NgayPhep = ngayPhep;
            KhongPhep = khongPhep;
            NgayLe = ngayLe;
            NgayChuNhat = ngayChuNhat;
            NgayThuong = ngayThuong;
            TangCa = tangCa;
            PhuCap = phuCap;
            ThucLanh = thucLanh;
            Created_By = created_By;
            Created_Date = created_Date;
            Updated_By = updated_By;
            Updated_Date = updated_Date;
            Deleted_By = deleted_By;
            Deleted_Date = deleted_Date;
        }
    }
}
