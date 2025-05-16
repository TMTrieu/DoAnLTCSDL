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
    public class YeuCauThoiViecDL : DataProvider
    {
        public List<YeuCauThoiViec> GetYeuCaus()
        {
            int idYC, idNV;
            string lyDo, loaiLyDo, trangThai, ghiChu;
            DateTime ngayYC;
            List<YeuCauThoiViec> yeuCaus = new List<YeuCauThoiViec>();
            string sql = "SELECT * FROM YeuCauThoiViec";
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    idYC = int.Parse(reader["IdYeuCau"].ToString());
                    idNV = int.Parse(reader["IdNhanVien"].ToString());
                    ngayYC = DateTime.Parse(reader["NgayYeuCau"].ToString());
                    lyDo = reader["LyDo"].ToString();
                    loaiLyDo = reader["LoaiLyDo"].ToString();
                    trangThai = reader["TrangThai"].ToString();
                    DateTime? ngayPD = reader["NgayPheDuyet"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(reader["NgayPheDuyet"].ToString());
                    ghiChu = reader["GhiChu"].ToString();

                    YeuCauThoiViec yeucau = new YeuCauThoiViec(idYC, idNV, ngayYC, lyDo, loaiLyDo, trangThai, ngayPD, ghiChu);

                    yeuCaus.Add(yeucau);
                }
                reader.Close();
                return yeuCaus;
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


        public bool AddYeuCau(YeuCauThoiViec yc)
        {
            // Nếu ID chưa có, tự gán ID nhỏ nhất chưa dùng
            if (yc.IdYeuCau == 0)
            {
                yc.IdYeuCau = GetNextAvailableIdYeuCau();
            }
            string sql = @"INSERT INTO YeuCauThoiViec (IdYeuCau, IdNhanVien, NgayYeuCau, LyDo, LoaiLyDo, TrangThai, NgayPheDuyet, GhiChu)
                           VALUES (" + yc.IdYeuCau + "," + yc.IdNhanVien + ", '" + yc.NgayYeuCau.ToString("yyyy-MM-ddTHH:mm:ss") + "',N'" + yc.LyDo + "',N'" + yc.LoaiLyDo + "',N'" + yc.TrangThai + "', NULL, NULL);" +
                           "SELECT SCOPE_IDENTITY();";
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


        public bool UpdateYeuCau(YeuCauThoiViec yc)
        {
            string ngayPheDuyetSql = yc.NgayPheDuyet.HasValue ? $"'{yc.NgayPheDuyet.Value:yyyy-MM-dd}'" : "NULL";

            string sql = @"UPDATE YeuCauThoiViec SET  TrangThai = N'" + yc.TrangThai +
                           "', NgayPheDuyet = " + ngayPheDuyetSql +
                           ", GhiChu = N'" + yc.GhiChu + "' WHERE IdYeuCau = " + yc.IdYeuCau;
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


        public int GetNextAvailableIdYeuCau()
        {
            string sql = @"
        SELECT MIN(t1.IdYeuCau + 1) AS NextId
        FROM YeuCauThoiViec t1
        LEFT JOIN YeuCauThoiViec t2 ON t1.IdYeuCau + 1 = t2.IdYeuCau
        WHERE t2.IdYeuCau IS NULL";

            try
            {
                Connect();
                object result = MyExecuteScalar(sql, CommandType.Text);
                if (result == DBNull.Value || result == null)
                {
                    return 1; // Bắt đầu từ 1 nếu bảng rỗng
                }
                else
                {
                    return Convert.ToInt32(result);
                }
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
