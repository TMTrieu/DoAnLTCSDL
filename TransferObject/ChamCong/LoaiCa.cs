using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class LoaiCa
    {
        public int IdLoaiCa { get; set; }
        public string TenLoaiCa { get; set; }
        public double HeSo { get; set; }
        public TimeSpan GioBatDau { get; set; } 
        public TimeSpan GioKetThuc { get; set; } 

        public LoaiCa() { }

        public LoaiCa(int id, string tenLoaiCa, TimeSpan gioBatDau, TimeSpan gioKetThuc, double heSo)
        {
            this.IdLoaiCa = id;
            this.TenLoaiCa = tenLoaiCa;
            this.GioBatDau = gioBatDau;
            this.GioKetThuc = gioKetThuc;
           this. HeSo = heSo;
        }
    }
}

