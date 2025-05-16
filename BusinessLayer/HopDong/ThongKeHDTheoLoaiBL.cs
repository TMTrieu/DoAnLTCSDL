using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class ThongKeHDTheoLoaiBL
    {
        ThongKeHDTheoLoaiDL dl = new ThongKeHDTheoLoaiDL();

        public List<ThongKeHDTheoLoai> LayDuLieuThongKeTheoNam(int nam)
        {
            return dl.LayThongKeTheoThoiHanTheoNam(nam);
        }

        public List<string> LayDanhSachThoiHanTheoNam(int nam)
        {
            return dl.LayThoiHanTheoNam(nam);
        }
        public List<ThongKeHDTheoLoai> LayDuLieuThongKeTheoNamVaThoiHan(int nam, string thoiHan)
        {
            return dl.LayThongKeTheoNamVaThoiHan(nam, thoiHan);
        }


    }
}
