using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class LoaiCa
    {
        public int ID { get; set; }
        public string TenLoaiCa { get; set; }
        public double HeSo { get; set; }
        public LoaiCa() { }
        public LoaiCa(int ID, string TenLoaiCa, double HeSo)
        {
            this.ID = ID;
            this.TenLoaiCa = TenLoaiCa;
            this.HeSo = HeSo;
        }

    }
}
