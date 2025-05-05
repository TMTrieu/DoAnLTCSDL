using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class PhongBan
    {
        public int IdPhongBan { get; set; }
        public string TenPhongBan { get; set; }

        public PhongBan() { }
        public PhongBan(int ID, string TenPB)
        {
            this.IdPhongBan = ID;
            this.TenPhongBan = TenPB;
        }
    }
}
