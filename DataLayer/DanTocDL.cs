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
    public class DanTocDL:DataProvider
    {
        public List<DanToc> GetDanTocs() { 
            List<DanToc> danTocs = new List<DanToc> ();
            string sql = "SELECT * FROM DanToc";
            int id;
            string ten;
            try
            {
                Connect();
                SqlDataReader dr = MyExcuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    id = int.Parse(dr["IdDanToc"].ToString());
                    ten = dr["TenDanToc"].ToString();

                    DanToc danToc = new DanToc(id, ten);
                    danTocs.Add(danToc);
                }

                dr.Close();
                return danTocs;
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
        public bool AddDanToc(DanToc danToc)
        {
            string sql = "INSERT INTO DanToc VALUES ("+danToc.IDDanToc +", N'"+ danToc.TenDanToc+"')";

            try
            {
                Connect();
                int result = MyExecuteNonQuery(sql, CommandType.Text);
                return result > 0;
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

        public bool UpdateDanToc(DanToc danToc)
        {
            string sql = "UPDATE DanToc SET TenDanToc ='" + danToc.TenDanToc + "' WHERE IdDanToc =" + danToc.IDDanToc;
            try
            {
                Connect();
                int result = MyExecuteNonQuery(sql,CommandType.Text );
                return result > 0;
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

        public bool DeleteDanToc(int id)
        {
            string sql = "DELETE FROM DanToc WHERE IDDanToc =" + id;

            try
            {
                Connect();

                int result = MyExecuteNonQuery(sql,CommandType.Text);
                return result > 0;
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
