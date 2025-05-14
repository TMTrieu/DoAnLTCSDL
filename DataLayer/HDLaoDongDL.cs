using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class HDLaoDongDL : DataProvider
    {
        public List<HDLaoDong> GetHopDongs()
        {
            List<HDLaoDong> list = new List<HDLaoDong>();
            string sql = @"SELECT * FROM HopDong WHERE Deleted_By IS NULL";

            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    HDLaoDong hd = new HDLaoDong();
                    hd.IdHopDong = (int)reader["IdHopDong"];
                    hd.SoHD = reader["SoHD"].ToString();
                    hd.NgayBatDau = (DateTime)reader["NgayBatDau"];
                    hd.NgayKetThuc = (DateTime)reader["NgayKetThuc"];
                    hd.NgayKy = (DateTime)reader["NgayKy"];
                    hd.ThoiHan = reader["ThoiHan"].ToString();
                    hd.NoiDung = reader["NoiDung"].ToString();
                    hd.HeSoLuong = float.Parse(reader["HeSoLuong"].ToString());
                    hd.LuongCoBan = (int)reader["LuongCoBan"];
                    hd.LanKy = int.Parse(reader["LanKy"].ToString());
                    hd.IdNhanVien = (int)reader["IdNhanVien"];
                    list.Add(hd);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return list;
        }

        public List<HDLaoDong> GetHopDongsWithNhanVien()
        {
            List<HDLaoDong> list = new List<HDLaoDong>();
            string sql = @"SELECT hd.*, nv.HoTen
                           FROM HopDong hd
                           JOIN NhanVien nv ON hd.IdNhanVien = nv.IdNhanVien
                           WHERE hd.Deleted_By IS NULL";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    HDLaoDong hd = new HDLaoDong
                    {
                        IdHopDong = (int)reader["IdHopDong"],
                        SoHD = reader["SoHD"].ToString(),
                        NgayBatDau = (DateTime)reader["NgayBatDau"],
                        NgayKetThuc = (DateTime)reader["NgayKetThuc"],
                        NgayKy = (DateTime)reader["NgayKy"],
                        NoiDung = reader["NoiDung"].ToString(),
                        LanKy = (int)reader["LanKy"],
                        ThoiHan = reader["ThoiHan"].ToString(),
                        HeSoLuong = float.Parse(reader["HeSoLuong"].ToString()),
                        LuongCoBan = (int)reader["LuongCoBan"],
                        IdNhanVien = (int)reader["IdNhanVien"],
                        HoTen = reader["HoTen"].ToString()
                    };
                    list.Add(hd);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            return list;
        }

        public HDLaoDong GetHopDongBySoHD(string soHD)
        {
            HDLaoDong hd = null;
            string sql = $@"SELECT hd.*, nv.HoTen, nv.CanCuocCongDan, nv.DiaChi, nv.DienThoai, nv.NgaySinh 
                            FROM HopDong hd
                            JOIN NhanVien nv ON hd.IdNhanVien = nv.IdNhanVien
                            WHERE hd.Deleted_By IS NULL AND hd.SoHD = N'{soHD}'";  // Giữ nguyên cách cũ bạn đang dùng

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                if (reader.Read())
                {
                    hd = new HDLaoDong
                    {
                        IdHopDong = (int)reader["IdHopDong"],
                        SoHD = reader["SoHD"].ToString(),
                        NgayBatDau = (DateTime)reader["NgayBatDau"],
                        NgayKetThuc = (DateTime)reader["NgayKetThuc"],
                        NgayKy = (DateTime)reader["NgayKy"],
                        NoiDung = reader["NoiDung"].ToString(),
                        LanKy = (int)reader["LanKy"],
                        ThoiHan = reader["ThoiHan"].ToString(),
                        HeSoLuong = float.Parse(reader["HeSoLuong"].ToString()),
                        LuongCoBan = (int)reader["LuongCoBan"],
                        IdNhanVien = (int)reader["IdNhanVien"],
                        HoTen = reader["HoTen"].ToString(),
                        CanCuocCongDan = reader["CanCuocCongDan"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]).ToString("dd/MM/yyyy")
                    };
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return hd;
        }

        public int GetAvailableId()
        {
            string sql = @"
                SELECT ISNULL(MIN(a.IdHopDong + 1), 1)
                FROM HopDong a
                LEFT JOIN HopDong b ON a.IdHopDong + 1 = b.IdHopDong 
                WHERE b.IdHopDong IS NULL";

            try
            {
                Connect();
                return (int)MyExecuteScalar(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string GetAvailableSoHD()
        {
            string prefix = "HD" + DateTime.Now.ToString("ddMMyyyy");
            string sql = $@"SELECT MAX(SoHD) FROM HopDong WHERE SoHD LIKE '{prefix}%'";

            string nextSoHD = prefix + "001";

            try
            {
                Connect();
                object result = MyExecuteScalar(sql, CommandType.Text);
                if (result != DBNull.Value && result != null)
                {
                    string lastId = result.ToString();
                    if (!string.IsNullOrEmpty(lastId) && lastId.Length >= prefix.Length + 3)
                    {
                        int number = int.Parse(lastId.Substring(prefix.Length));
                        number++;
                        nextSoHD = prefix + number.ToString("D3");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return nextSoHD;
        }

        public int Add(HDLaoDong hd)
        {
            string sql = @"INSERT INTO HopDong(IdHopDong, SoHD, NgayBatDau, NgayKetThuc, NgayKy, NoiDung, LanKy, ThoiHan, HeSoLuong,LuongCoBan, IdNhanVien, Created_By, Created_Date, Deleted_By, Deleted_Date)
                           VALUES (@IdHopDong, @SoHD, @NgayBatDau, @NgayKetThuc, @NgayKy, @NoiDung, @LanKy, @ThoiHan, @HeSoLuong,@LuongCoBan, @IdNhanVien, @Created_By, @Created_Date, NULL, NULL)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdHopDong", hd.IdHopDong),
                new SqlParameter("@SoHD", hd.SoHD),
                new SqlParameter("@NgayBatDau", hd.NgayBatDau),
                new SqlParameter("@NgayKetThuc", hd.NgayKetThuc),
                new SqlParameter("@NgayKy", hd.NgayKy),
                new SqlParameter("@NoiDung", hd.NoiDung),
                new SqlParameter("@LanKy", hd.LanKy),
                new SqlParameter("@ThoiHan", hd.ThoiHan),
                new SqlParameter("@HeSoLuong", hd.HeSoLuong),
                new SqlParameter("@LuongCoBan", hd.LuongCoBan),
                new SqlParameter("@IdNhanVien", hd.IdNhanVien),
                new SqlParameter("@Created_By", hd.Created_By),
                new SqlParameter("@Created_Date", hd.Created_Date)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public int Update(HDLaoDong hd)
        {
            string sql = @"UPDATE HopDong 
                           SET NgayBatDau = @NgayBatDau, 
                               NgayKetThuc = @NgayKetThuc, 
                               NgayKy = @NgayKy,
                               NoiDung = @NoiDung, 
                               LanKy = @LanKy, 
                               ThoiHan = @ThoiHan,
                               HeSoLuong = @HeSoLuong,
                               LuongCoBan=@LuongCoBan,
                               IdNhanVien = @IdNhanVien,
                               Updated_By = @Updated_By,
                               Updated_Date = @Updated_Date
                           WHERE SoHD = @SoHD";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@NgayBatDau", hd.NgayBatDau),
                new SqlParameter("@NgayKetThuc", hd.NgayKetThuc),
                new SqlParameter("@NgayKy", hd.NgayKy),
                new SqlParameter("@NoiDung", hd.NoiDung),
                new SqlParameter("@LanKy", hd.LanKy),
                new SqlParameter("@ThoiHan", hd.ThoiHan),
                new SqlParameter("@HeSoLuong", hd.HeSoLuong),
                new SqlParameter("@LuongCoBan", hd.LuongCoBan),
                new SqlParameter("@IdNhanVien", hd.IdNhanVien),
                new SqlParameter("@Updated_By", hd.Updated_By),
                new SqlParameter("@Updated_Date", hd.Updated_Date),
                new SqlParameter("@SoHD", hd.SoHD)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters);
        }

        public int Delete(string soHD, int deletedBy)
        {
            string sql = @"UPDATE HopDong
                   SET Deleted_By = " + deletedBy + ",  Deleted_Date = " + DateTime.Now + "   WHERE SoHD = " + soHD;
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
