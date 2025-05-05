using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class ChucVu
    {
        public int IdChucVu {  get; set; }
        public string TenChucVu { get; set; }

        public ChucVu() { }
        public ChucVu(int id, string name) 
        { 
            this.IdChucVu = id; 
            this.TenChucVu = name;
        }
    }
}
