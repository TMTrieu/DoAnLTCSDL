using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer 
{
    public class LoginDL : DataProvider
    {
        public bool Login(Account account)
        {
            /*string sql = "SELECT COUNT (USERNAME) FROM Users WHERE USERNAME = '" + account.UserName + "' AND PASSWORD ='" + account.Password + "'";
            try
            {
                return ((int)MyExcuteScalar(sql, CommandType.Text) > 0);
            }
            catch (SqlException ex) {
                throw ex;
            }*/

            if (account.UserName == "admin" && account.Password =="123")
                return true;
            else return false;
        }
    }
}
