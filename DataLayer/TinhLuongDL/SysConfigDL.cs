using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class SysConfigDL:DataProvider
    {
        public SysConfig GetItem(string name)
        {
            SysConfig config = null;
            string sql = $"SELECT TOP 1 * FROM SysConfig WHERE Name = '{name}'";
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                if (dr.Read())
                {
                    config = new SysConfig
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Name = dr["Name"].ToString(),
                        Value = dr["Value"].ToString()
                    };
                }
                dr.Close();
                return config;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

    }
}
