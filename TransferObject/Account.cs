using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Account( string UserName, string Password) {
            this.UserName = UserName;
            this.Password = Password;
        }
    }
}
