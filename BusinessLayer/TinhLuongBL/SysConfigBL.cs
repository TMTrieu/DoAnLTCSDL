using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class SysConfigBL
    {
        private SysConfigDL sysConfigDL;

        public SysConfigBL()
        {
            sysConfigDL = new SysConfigDL();
        }

        public SysConfig GetItem(string name)
        {
            return sysConfigDL.GetItem(name);
        }
    }
}
