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
        public float NgayCongTrongThang  { get; set; }
        public float  NgayPhep { get; set; }
       
        public float  CongNgayLe {  get; set; }
        public float  CongNgayNghi  { get; set; }
        public float TongNgayCong { get; set; }
        public float TangCa { get; set; }
        public float PhuCap { get; set; }
        public float ThucLanh { get; set; }

        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }
       

        public BangLuong(int idBangLuong, int maKyCong, int idNhanVien, string hoTen, float ngayCongTrongThang, float ngayPhep,  float congngayLe, float congngayNghi, float tongngayCong, float tangCa, float phuCap, float thucLanh, int? created_By, DateTime? created_Date, int? updated_By, DateTime? updated_Date)
        {
            IdBangLuong = idBangLuong;
            MaKyCong = maKyCong;
            IdNhanVien = idNhanVien;
            HoTen = hoTen;
            NgayCongTrongThang = ngayCongTrongThang;
            NgayPhep = ngayPhep;
           
            CongNgayLe = congngayLe;
            CongNgayNghi = congngayNghi;
            TongNgayCong = tongngayCong;
            TangCa = tangCa;
            PhuCap = phuCap;
            ThucLanh = thucLanh;
            Created_By = created_By;
            Created_Date = created_Date;
            Updated_By = updated_By;
            Updated_Date = updated_Date;
           
        }
    }
}
