using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SysConfig
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Value { get; set; }
        public SysConfig() { }
        public SysConfig(int iD, string name, string value)
        {
            this.ID = iD;
            this.Name = name;
            this.Value = value;
        }
    }
}
