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
    public class TrinhDoDL : DataProvider
    {
        public List<TrinhDo> GetTrinhDos()
        {
            List<TrinhDo> trinhDos = new List<TrinhDo>();
            string sql = "SELECT * FROM TrinhDo";
            int id;
            string ten;
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    id = int.Parse(dr["IdTrinhDo"].ToString());
                    ten = dr["TenTrinhDo"].ToString();

                    TrinhDo trinhDo = new TrinhDo(id, ten);
                    trinhDos.Add(trinhDo);
                }

                dr.Close();
                return trinhDos;
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
        public bool AddTrinhDo(TrinhDo trinhDo)
        {
            string sql = "INSERT INTO TrinhDo VALUES (" + trinhDo.IdTrinhDo + ", N'" + trinhDo.TenTrinhDo + "')";

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

        public bool UpdateTrinhDo(TrinhDo trinhDo)
        {
            string sql = "UPDATE TrinhDo SET TenTrinhDo ='" + trinhDo.TenTrinhDo + "' WHERE IdTrinhDo =" + trinhDo.IdTrinhDo;
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

        public bool DeleteTrinhDo(int id)
        {
            string sql = "DELETE FROM TrinhDo WHERE IdTrinhDo =" + id;

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
