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
    public class LoaiCaDL:DataProvider
    {
        public List<LoaiCa> GetLoaiCas()
        {
            List<LoaiCa> loaiCas = new List<LoaiCa>();
            string sql = "SELECT * FROM LoaiCa";
            int id;
            string ten;
            double heSo;
            try
            {
                Connect();
                SqlDataReader dr = MyExcuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    id = int.Parse(dr["IdLoaiCa"].ToString());
                    ten = dr["TenLoaiCa"].ToString();
                    heSo = double.Parse(dr[2].ToString());

                    LoaiCa loaiCa = new LoaiCa(id, ten, heSo);
                    loaiCas.Add(loaiCa);
                }

                dr.Close();
                return loaiCas;
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
        public bool AddLoaiCa(LoaiCa loaiCa)
        {
            string sql = "INSERT INTO LoaiCa VALUES (" + loaiCa.ID + ", N'" + loaiCa.TenLoaiCa + "', "+loaiCa.HeSo+")";

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

        public bool UpdateLoaiCa(LoaiCa loaiCa)
        {
            string sql = "UPDATE LoaiCa SET TenLoaiCa ='" + loaiCa.TenLoaiCa + "', HeSo = "+loaiCa.HeSo+" WHERE IdLoaiCa =" + loaiCa.ID;
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

        public bool DeleteLoaiCa(int id)
        {
            string sql = "DELETE FROM LoaiCa WHERE IDLoaiCa =" + id;

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
