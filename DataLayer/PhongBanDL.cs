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
    public class PhongBanDL : DataProvider
    {
        public List<PhongBan> GetPhongBans()
        {
            int id;
            string name;
            List<PhongBan> phongBans = new List<PhongBan>();
            string sql = "SELECT * FROM PhongBan";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = int.Parse(reader["IdPhongBan"].ToString()); 
                    name = reader["TenPhongBan"].ToString();

                    PhongBan phongban = new PhongBan(id, name);
                    phongBans.Add(phongban);
                }
                //cách 2
                //while (reader.Read())
                //{
                //    phongBans.Add(new PhongBan(int.Parse(reader[0].ToString()), reader[1].ToString()));
                //}
                reader.Close();
                return phongBans;
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
        
        
        public bool AddPhongBan(PhongBan phongBan)
        {

            string sql = "INSERT INTO PhongBan VALUES (" + phongBan.IdPhongBan + ", N'" + phongBan.TenPhongBan + "')";

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
        public bool UpdatePhongBan(PhongBan phongBan)
        {
            string sql = "UPDATE PhongBan SET TenPhongBan = N'" + phongBan.TenPhongBan + "' WHERE IdPhongBan =" + phongBan.IdPhongBan;
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

        public bool DeletePhongBan(int id)
        {
            string sql = "DELETE FROM PhongBan WHERE IdPhongBan = "+id;
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
