using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class LoaiCong
    {
        public int ID { get; set; }
        public string TenLoaiCong { get; set; }
        public double HeSo { get; set; }
        public LoaiCong() { }
        public LoaiCong(int ID, string TenLoaiCong, double HeSo)
        {
            this.ID = ID;
            this.TenLoaiCong = TenLoaiCong;
            this.HeSo = HeSo;
        }
    }
}
