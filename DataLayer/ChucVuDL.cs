using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class ChucVuDL : DataProvider
    {
        public List<ChucVu> GetChucVus()
        {
            int id;
            string name;
            List<ChucVu> chucVus = new List<ChucVu>();
            string sql = "SELECT * FROM ChucVu";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = int.Parse(reader["IdChucVu"].ToString());
                    name = reader["TenChucVu"].ToString();

                    ChucVu chucvu = new ChucVu(id, name);
                    chucVus.Add(chucvu);
                }
                reader.Close();
                return chucVus;
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
       

        public bool AddChucVu(ChucVu chucVu)
        {
            string sql = "INSERT INTO ChucVu VALUES (" + chucVu.IdChucVu + ", N'" + chucVu.TenChucVu + "')"; 
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
        public bool UpdateChucVu(ChucVu chucVu)
        {
            string sql = "UPDATE ChucVu SET TenChucVu ='" + chucVu.TenChucVu + "' WHERE IdChucVu =" + chucVu.IdChucVu;

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

        public bool DeleteChucVu(int id)
        {
            string sql = "DELETE FROM ChucVu WHERE IdChucVu = " + id;
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
