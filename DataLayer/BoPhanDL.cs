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
    public class BoPhanDL : DataProvider
    {
        public List<BoPhan> GetBoPhans()
        {
            int id;
            string name;
            List<BoPhan> boPhans = new List<BoPhan>();
            string sql = "SELECT * FROM BoPhan";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = int.Parse(reader["IdBoPhan"].ToString());
                    name = reader["TenBoPhan"].ToString();

                    BoPhan bophan = new BoPhan(id, name);
                    boPhans.Add(bophan);
                }
                reader.Close();
                return boPhans;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        
        public bool AddBoPhan(BoPhan boPhan)
        {
            string sql = "INSERT INTO BoPhan VALUES (" + boPhan.IdBoPhan + ", '" + boPhan.TenBoPhan + "')";
            try
            {
                Connect();
                int result = MyExecuteNonQuery(sql, CommandType.Text);
                return result > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
        public bool UpdateBoPhan(BoPhan boPhan)
        {
            string sql = "UPDATE BoPhan SET TenBoPhan = N'"+boPhan.TenBoPhan+"'  WHERE IdBoPhan = "+boPhan.IdBoPhan;
            try
            {
                Connect();
                int result = MyExecuteNonQuery(sql,CommandType.Text);
                return (result > 0);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool DeleteBoPhan(int id)
        {
            string sql = "DELETE FROM BoPhan WHERE IdBoPhan = "+id;
            try
            {
                Connect();
                int result = MyExecuteNonQuery(sql, CommandType.Text);
                return result > 0;
            }
            catch (SqlException ex)
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
