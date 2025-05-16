using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class KyCongChiTiet
    {
        public int MaKyCong { get; set; }
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public List<string> ChamCong { get; set; } = new List<string>();
        public Double NgayCong { get; set; }
        public Double NgayPhep { get; set; }
        public Double NghiKhongPhep { get; set; }
        public Double CongNgayLe { get; set; }
        public Double CongNgayNghi { get; set; }
        public Double TongNgayCong { get; set; }

        public string D1 => ChamCong[0];
        public string D2 => ChamCong[1];
        public string D3 => ChamCong[2];
        public string D4 => ChamCong[3] ;
        public string D5 =>  ChamCong[4] ;
        public string D6 =>ChamCong[5] ;
        public string D7 => ChamCong[6] ;
        public string D8 => ChamCong[7] ;
        public string D9 => ChamCong[8] ;
        public string D10 => ChamCong[9] ;
        public string D11 => ChamCong[10] ;
        public string D12 => ChamCong[11] ;
        public string D13 => ChamCong[12] ;
        public string D14 => ChamCong[13] ;
        public string D15 => ChamCong[14] ;
        public string D16 => ChamCong[15] ;
        public string D17 =>ChamCong[16] ;
        public string D18 => ChamCong[17] ;
        public string D19 =>ChamCong[18] ;
        public string D20 =>  ChamCong[19] ;
        public string D21 => ChamCong[20] ;
        public string D22 => ChamCong[21] ;
        public string D23 => ChamCong[22] ;
        public string D24 => ChamCong[23] ;
        public string D25 => ChamCong[24] ;
        public string D26 => ChamCong[25] ;
        public string D27 => ChamCong[26] ;
        public string D28 => ChamCong[27] ;
        public string D29 => ChamCong[28] ;
        public string D30 => ChamCong[29] ;
        public string D31 => ChamCong[30] ;
        public KyCongChiTiet() { }
        public KyCongChiTiet(int maKC, int maNV, string hoTen, List<string> ChamCong)
        {
            this.MaKyCong = maKC;
            this.MaNhanVien = maNV;
            this.HoTen = hoTen;
            this.ChamCong = ChamCong;
        }
        public KyCongChiTiet(int maKC, int maNV, string hoTen, List<string> ChamCong, int NgayCong, int NgayPhep, int NghiKhongPhep, int CongNgayLe, int CongNgayNghi, int TongNgayCong)
        {
            this.MaKyCong = maKC;
            this.MaNhanVien = maNV;
            this.HoTen = hoTen;
            this.ChamCong = ChamCong;
            this.NgayCong = NgayCong;
            this.TongNgayCong = TongNgayCong;
            this.CongNgayLe = CongNgayLe;
            this.CongNgayNghi = CongNgayNghi;
            this.NghiKhongPhep = NghiKhongPhep;
            this.NgayPhep = NgayPhep;
        }
    } }
