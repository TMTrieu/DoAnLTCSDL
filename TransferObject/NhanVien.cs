using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
namespace TransferObject
{
    public class NhanVien
    {
        public int IdNhanVien { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public byte[] HinhAnh { get; set; }
        public int IdBoPhan { get; set; }
        public int IdPhongBan { get; set; }
        public int IdChucVu { get; set; }
        public int IdTrinhDo { get; set; }
        public int IdDanToc { get; set; }
        public int IdTonGiao { get; set; }

        public string TenPhongBan { get; set; }
        public string TenBoPhan { get; set; }
        public string TenChucVu { get; set; }
        public string TenTrinhDo { get; set; }
        public string TenDanToc { get; set; }
        public string TenTonGiao { get; set; }
        public NhanVien() { }
        
        public NhanVien(int id, string name, bool gioiTinh, DateTime ngay, string phone, string cccd,
            string diachi, byte[] hinhanh,
            int idPB, int idBP, int idCV, int idTD, int idDT, int idTG)
        {
            this.IdNhanVien = id;
            this.HoTen = name;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngay;
            this.DienThoai = phone;
            this.CCCD = cccd;
            this.DiaChi = diachi;
            this.HinhAnh = hinhanh;
            this.IdPhongBan = idPB;
            this.IdBoPhan = idBP;
            this.IdChucVu = idCV;
            this.IdTrinhDo = idTD;
            this.IdDanToc = idDT;
            this.IdTonGiao = idTG;
        }

        // Constructor đầy đủ với cả ID và tên
        public NhanVien(int id, string name, bool gioiTinh, DateTime ngay, string phone, string cccd,
            string diachi, byte[] hinhanh,
            int idPB, string tenPB,
            int idBP, string tenBP,
            int idCV, string tenCV,
            int idTD, string tenTD,
            int idDT, string tenDT,
            int idTG, string tenTG)
        {
            this.IdNhanVien = id;
            this.HoTen = name;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngay;
            this.DienThoai = phone;
            this.CCCD = cccd;
            this.DiaChi = diachi;
            this.HinhAnh = hinhanh;

            this.IdPhongBan = idPB;
            this.TenPhongBan = tenPB;

            this.IdBoPhan = idBP;
            this.TenBoPhan = tenBP;

            this.IdChucVu = idCV;
            this.TenChucVu = tenCV;

            this.IdTrinhDo = idTD;
            this.TenTrinhDo = tenTD;

            this.IdDanToc = idDT;
            this.TenDanToc = tenDT;

            this.IdTonGiao = idTG;
            this.TenTonGiao = tenTG;
        }
    }
}
