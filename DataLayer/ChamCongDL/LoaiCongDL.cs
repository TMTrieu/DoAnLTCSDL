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
    public class LoaiCongDL : DataProvider
    {
        public List<LoaiCong> GetLoaiCongs()
        {
            List<LoaiCong> loaiCongs = new List<LoaiCong>();
            string sql = "SELECT * FROM LoaiCong";
            int id;
            string ten;
            double heSo;
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    id = int.Parse(dr["IdLoaiCong"].ToString());
                    

                    ten = dr["TenLoaiCong"].ToString();
                    heSo = double.Parse(dr[2].ToString());

                    LoaiCong loaiCong = new LoaiCong(id, ten, heSo);
                    loaiCongs.Add(loaiCong);
                }

                dr.Close();
                return loaiCongs;
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
        public bool AddLoaiCong(LoaiCong loaiCong)
        {
            string sql = "INSERT INTO LoaiCong VALUES (" + loaiCong.ID + ", N'" + loaiCong.TenLoaiCong + "', " + loaiCong.HeSo + ")";

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

        public bool UpdateLoaiCong(LoaiCong loaiCong)
        {
            string sql = "UPDATE LoaiCong SET TenLoaiCong ='" + loaiCong.TenLoaiCong + "', HeSo = " + loaiCong.HeSo + " WHERE IdLoaiCong =" + loaiCong.ID;
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

        public bool DeleteLoaiCong(int id)
        {
            string sql = "DELETE FROM LoaiCong WHERE IdLoaiCong =" + id;

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
