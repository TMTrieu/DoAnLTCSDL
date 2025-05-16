using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public  class ThongKeHDTheoLoai
    {
        public string LoaiHopDong { get; set; }
        public int SoLuong { get; set; }
       
        public ThongKeHDTheoLoai() { }

        public ThongKeHDTheoLoai(string loaiHopDong, int soLuong)
        {
            LoaiHopDong = loaiHopDong;
            SoLuong = soLuong;
        }
    }
}
