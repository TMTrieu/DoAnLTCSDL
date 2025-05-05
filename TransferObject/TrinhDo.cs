using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TrinhDo
    {
        public int IdTrinhDo { get; set; }
        public string TenTrinhDo { get; set; }
        public TrinhDo() { }
        public TrinhDo(int id, string ten)
        {
            this.IdTrinhDo = id;
            this.TenTrinhDo = ten;
        }
    }
}
