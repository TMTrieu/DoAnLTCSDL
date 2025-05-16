using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class BangCongChiTiet
    {
        public int IdBangCong { get; set; }
        public int MaKyCong { get; set; }
        public int IdNhanVien { get; set; }
        public DateTime NgayChamCong { get; set; }
        public int IdLoaiCa { get; set; }
        public int IdLoaiCong { get; set; }
        public TimeSpan ThoiGianVao { get; set; } 
        public TimeSpan ThoiGianRa { get; set; }

        public string TenLoaiCa { get; set; }
        public string TenLoaiCong { get; set; }

        public string ChamCong { get; set; }
        public BangCongChiTiet() { }

        public BangCongChiTiet(int maKyCong, int idNhanVien, DateTime ngayChamCong,
            int idLoaiCa, int idLoaiCong, TimeSpan thoiGianVao, TimeSpan thoiGianRa, string chamCong)
        {
            MaKyCong = maKyCong;
            IdNhanVien = idNhanVien;
            NgayChamCong = ngayChamCong;
            IdLoaiCa = idLoaiCa;
            IdLoaiCong = idLoaiCong;
            ThoiGianVao = thoiGianVao;
            ThoiGianRa = thoiGianRa;
            ChamCong = chamCong;
        }
    }
}
