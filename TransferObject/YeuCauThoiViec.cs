using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public  class YeuCauThoiViec
    {
        public int IdYeuCau { get; set; }
        public int IdNhanVien { get; set; }
        public DateTime NgayYeuCau { get; set; }
        public string LyDo { get; set; }
        public string LoaiLyDo { get; set; }

        public string TrangThai { get; set; }
        public DateTime? NgayPheDuyet { get; set; }
        public string GhiChu { get; set; }

        public YeuCauThoiViec(int maYeuCau, int maNhanVien, DateTime ngayYeuCau, string lyDo, string loaiLyDo, string trangThai, DateTime? ngayPheDuyet, string ghiChu)
        {
            IdYeuCau = maYeuCau;
            IdNhanVien = maNhanVien;
            NgayYeuCau = ngayYeuCau;
            LyDo = lyDo;
            LoaiLyDo = loaiLyDo;
            TrangThai = trangThai;
            NgayPheDuyet = ngayPheDuyet;
            GhiChu = ghiChu;
        }
        public YeuCauThoiViec() { }

    }
}
