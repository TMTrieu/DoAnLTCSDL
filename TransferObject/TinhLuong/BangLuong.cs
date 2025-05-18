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
        public double NgayCongTrongThang  { get; set; }
        public double  NgayPhep { get; set; }
       
        public double  CongNgayLe {  get; set; }
        public double  CongNgayNghi  { get; set; }
        public double TongNgayCong { get; set; }
        public double TangCa { get; set; }
        public double PhuCap { get; set; }
        public double ThucLanh { get; set; }


       

        public BangLuong(int idBangLuong, int maKyCong, int idNhanVien, string hoTen, double ngayCongTrongThang, double ngayPhep,  double congngayLe, double congngayNghi, double tongngayCong, double tangCa, double phuCap, double thucLanh)
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
          
           
        }
    }
}
