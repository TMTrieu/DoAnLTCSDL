using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class DanToc
    {
        public int IDDanToc { get; set; }
        public string TenDanToc { get; set; }

        public DanToc(int ID, string Ten) {
            this.IDDanToc = ID;
            this.TenDanToc= Ten;
        }
    }
}
