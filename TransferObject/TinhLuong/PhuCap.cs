using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class PhuCap
    {
        
            public int IdPhuCap { get; set; }
            public string TenPhuCap { get; set; }
            public double SoTien {  get; set; }
             public PhuCap() { }

           
            public PhuCap(int id, string TenPC,double soTien)
            {
                this.IdPhuCap = id;
                this.TenPhuCap = TenPC;
                this.SoTien = soTien;
            }
        }
    
}
