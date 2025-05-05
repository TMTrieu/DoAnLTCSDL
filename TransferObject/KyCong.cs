using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class KyCong
    {

        public int ID { get; set; }
        public int MaKyCong { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public bool Khoa { get; set; }
        public DateTime NgayTinhCong { get; set; }
        public double SoNgayCong { get; set; }
        public bool TrangThai { get; set; }

        public KyCong() { }

        public KyCong(int id, int maKyCong, int thang, int nam, bool khoa, DateTime ngayTinhCong, double soNgayCong, bool trangThai)
        {
            ID = id;
            MaKyCong = maKyCong;
            Thang = thang;
            Nam = nam;
            Khoa = khoa;
            NgayTinhCong = ngayTinhCong;
            SoNgayCong = soNgayCong;
            TrangThai = trangThai;
        }

    }
}
