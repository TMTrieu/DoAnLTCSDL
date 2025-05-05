using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TonGiao
    {
        public int IdTonGiao { get; set; }
        public string TenTonGiao { get; set; }
        public TonGiao() { }
        public TonGiao(int id, string ten)
        {
            this.IdTonGiao = id;
            this.TenTonGiao = ten;
        }
    }
}
