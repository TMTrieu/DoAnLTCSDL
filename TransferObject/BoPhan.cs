using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class BoPhan
    {
        public int IdBoPhan { get; set; }
        public string TenBoPhan { get; set; }
        public BoPhan() { }
        public BoPhan(int id, string name)
        {
            this.IdBoPhan = id;
            this.TenBoPhan = name;
        }
    }
}
