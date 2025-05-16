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
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["IdLoaiCa"]);
                    
                    string ten = dr["TenLoaiCa"].ToString();
                    TimeSpan gioBatDau = TimeSpan.Parse(dr["GioBatDau"].ToString());
                    TimeSpan gioKetThuc = TimeSpan.Parse(dr["GioKetThuc"].ToString());
                    float heSo = float.Parse(dr["HeSo"].ToString());

                    LoaiCa loaiCa = new LoaiCa(id, ten, gioBatDau, gioKetThuc, heSo);
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
        public LoaiCa GetItem(int id)
        {
            LoaiCa result = null;
            string sql = $"SELECT * FROM LoaiCa WHERE IdLoaiCa = {id}";

            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                if (dr.Read())
                {
                    result = new LoaiCa
                    {
                        IdLoaiCa = Convert.ToInt32(dr["IdLoaiCa"]),
                        TenLoaiCa = dr["TenLoaiCa"].ToString(),
                        HeSo = float.Parse(dr["HeSo"].ToString()),
                        GioBatDau = TimeSpan.Parse(dr["GioBatDau"].ToString()),
                        GioKetThuc = TimeSpan.Parse(dr["GioKetThuc"].ToString())
                       
                    };
                }
                dr.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy Loai Ca: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool AddLoaiCa(LoaiCa loaiCa)
        {
            string sql = "INSERT INTO LoaiCa VALUES (" + loaiCa.IdLoaiCa + ", N'" + loaiCa.TenLoaiCa + "', "+loaiCa.HeSo+")";

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
            string sql = "UPDATE LoaiCa SET TenLoaiCa ='" + loaiCa.TenLoaiCa + "', HeSo = "+loaiCa.HeSo+" WHERE IdLoaiCa =" + loaiCa.IdLoaiCa;
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
