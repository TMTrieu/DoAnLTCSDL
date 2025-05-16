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
    public class TonGiaoDL : DataProvider
    {
        public List<TonGiao> GetTonGiaos()
        {
            List<TonGiao> tonGiaos = new List<TonGiao>();
            string sql = "SELECT * FROM TonGiao";
            int id;
            string ten;
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    id = int.Parse(dr["IdTonGiao"].ToString());
                    ten = dr["TenTonGiao"].ToString();

                    TonGiao tonGiao = new TonGiao(id, ten);
                    tonGiaos.Add(tonGiao);
                }

                dr.Close();
                return tonGiaos;
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
        public bool AddTonGiao(TonGiao tonGiao)
        {
            string sql = "INSERT INTO TonGiao VALUES (" + tonGiao.IdTonGiao + ", N'" + tonGiao.TenTonGiao + "')";

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

        public bool UpdateTonGiao(TonGiao tonGiao)
        {
            string sql = "UPDATE TonGiao SET TenTonGiao ='" + tonGiao.TenTonGiao + "' WHERE IdTonGiao =" + tonGiao.IdTonGiao;
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

        public bool DeleteTonGiao(int id)
        {
            string sql = "DELETE FROM TonGiao WHERE IdTonGiao =" + id;

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

    }
}
