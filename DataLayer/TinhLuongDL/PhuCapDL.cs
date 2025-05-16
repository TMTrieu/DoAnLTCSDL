using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class PhuCapDL : DataProvider
    {
        public List<PhuCap> GetPhuCaps()
        {
            List<PhuCap> ds = new List<PhuCap>();
            string sql = "SELECT * FROM PhuCap";

            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    int id = int.Parse(dr["IdPhuCap"].ToString());
                    string ten = dr["TenPhuCap"].ToString();
                    float soTien = float.Parse(dr["SoTien"].ToString());

                    ds.Add(new PhuCap(id, ten, soTien));
                }
                dr.Close();
                return ds;
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

        public PhuCap GetItemPhuCap(int id)
        {
            PhuCap pc = null;
            string sql = $"SELECT * FROM PhuCap WHERE IdPhuCap = {id}";

            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                if (dr.Read())
                {
                    pc = new PhuCap(
                        int.Parse(dr["IdPhuCap"].ToString()),
                        dr["TenPhuCap"].ToString(),
                        float.Parse(dr["SoTien"].ToString())
                    );
                }
                dr.Close();
                return pc;
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

        public int GetAvailableId()
        {
            string sql = @"
                SELECT ISNULL(MIN(a.IdPhuCap + 1), 1) AS NextID
                FROM PhuCap a
                LEFT JOIN PhuCap b ON a.IdPhuCap + 1 = b.IdPhuCap
                WHERE b.IdPhuCap IS NULL";

            try
            {
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Add(PhuCap pc)
        {
            string sql = $"INSERT INTO PhuCap VALUES ({pc.IdPhuCap}, N'{pc.TenPhuCap}', {pc.SoTien})";
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

        public bool Update(PhuCap pc)
        {
            string sql = $"UPDATE PhuCap SET TenPhuCap = N'{pc.TenPhuCap}', SoTien = {pc.SoTien} WHERE IdPhuCap = {pc.IdPhuCap}";
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

        public bool Delete(int id, int? deletedBy = null)
        {
            string sql = @"
        UPDATE TangCa SET 
            Deleted_By = @Deleted_By,
            Deleted_Date = @Deleted_Date
        WHERE IdPhuCap = @IdPhuCap";

            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@Deleted_By", deletedBy ?? (object)DBNull.Value),
        new SqlParameter("@Deleted_Date", DateTime.Now),
        new SqlParameter("@IdPhuCap", id)
    };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }
    }
}
