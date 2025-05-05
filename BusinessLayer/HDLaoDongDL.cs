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
            string sql = @"SELECT * FROM HopDong WHERE Deleted_By IS NULL" ;

            try
            {
                SqlDataReader reader = MyExcuteReader(sql,CommandType.Text);
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
            List<HDLaoDong> hdlaodongs = new List<HDLaoDong>();
            string sql = @"SELECT hd.*, nv.HoTen
                   FROM HopDong hd
                   JOIN NhanVien nv ON hd.IdNhanVien = nv.IdNhanVien
                   WHERE hd.Deleted_By IS NULL";

            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    HDLaoDong hdlaodong = new HDLaoDong
                    {
                        IdHopDong = Convert.ToInt32(reader["IdHopDong"]),
                        SoHD = reader["SoHD"].ToString(),
                        NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]),
                        NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]),
                        NgayKy = Convert.ToDateTime(reader["NgayKy"]),
                        NoiDung = reader["NoiDung"].ToString(),
                        LanKy = Convert.ToInt32(reader["LanKy"]),
                        ThoiHan = reader["ThoiHan"].ToString(),
                        HeSoLuong = float.Parse(reader["HeSoLuong"].ToString()),
                        IdNhanVien = Convert.ToInt32(reader["IdNhanVien"]),
                        HoTen = reader["HoTen"].ToString(),
                       
                    };

                    hdlaodongs.Add(hdlaodong);
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
            return hdlaodongs;
        }
        public HDLaoDong GetHopDongBySoHD(string soHD)
        {
            List<HDLaoDong> list = new List<HDLaoDong>();

            HDLaoDong hdlaodong = new HDLaoDong();

            string sql = @"SELECT hd.*, nv.HoTen, nv.CanCuocCongDan, nv.DiaChi, nv.DienThoai, nv.NgaySinh 
                   FROM HopDong hd
                   JOIN NhanVien nv ON hd.IdNhanVien = nv.IdNhanVien
                   WHERE hd.Deleted_By IS NULL AND hd.SoHD = "+soHD;

            try
            {
                
                SqlDataReader reader = MyExcuteReader(sql,CommandType.Text);
                if (reader.Read())
                {
                    hdlaodong = new HDLaoDong
                    {
                        IdHopDong = Convert.ToInt32(reader["IdHopDong"]),
                        SoHD = reader["SoHD"].ToString(),
                        NgayBatDau = Convert.ToDateTime(reader["NgayBatDau"]),
                        NgayKetThuc = Convert.ToDateTime(reader["NgayKetThuc"]),
                        NgayKy = Convert.ToDateTime(reader["NgayKy"]),
                        NoiDung = reader["NoiDung"].ToString(),
                        LanKy = Convert.ToInt32(reader["LanKy"]),
                        ThoiHan = reader["ThoiHan"].ToString(),
                        HeSoLuong = float.Parse(reader["HeSoLuong"].ToString()),
                        IdNhanVien = Convert.ToInt32(reader["IdNhanVien"]),
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
            return hdlaodong;
        }

        public int GetAvailableId()
        {
            string sql = @"
                SELECT ISNULL(MIN(a.IdHopDong + 1), 1) AS NextID
                FROM HopDong a
                LEFT JOIN HopDong b ON a.IdHopDong + 1 = b.IdHopDong 
                WHERE b.IdHopDong IS NULL";

            try
            {
                Connect();
               return (int)MyExcuteScalar(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        public string GetAvailableSoHD()
        {
            string prefix = "HD" + DateTime.Now.ToString("ddMMyyyy");
            string sql = @"SELECT MAX(SoHD) FROM HopDong WHERE SoHD LIKE "+ prefix + " + '%'";

            string nextSoHD = prefix + "001"; // Default nếu chưa có

            try
            {
                Connect();
                object result = MyExcuteScalar(sql, CommandType.Text);
                if (result != DBNull.Value && result != null)
                {
                    string lastId = result.ToString();
                    if (!string.IsNullOrEmpty(lastId) && lastId.Length >= 11)
                    {
                        int number = int.Parse(lastId.Substring(10)); 
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


        public int Add(HDLaoDong hdld)
        {
            string sql = "INSERT INTO HopDong(IdHopDong, SoHD, NgayBatDau, NgayKetThuc, NgayKy, NoiDung, LanKy, ThoiHan, HeSoLuong, IdNhanVien, Created_By, Created_Date, Deleted_By, Deleted_Date) VALUES (" +
    hdld.IdHopDong + ", " +     "N'" + hdld.SoHD + "', " +    "'" + hdld.NgayBatDau.ToString("yyyy-MM-dd") + "', " +
    "'" + hdld.NgayKetThuc.ToString("yyyy-MM-dd") + "', " +    "'" + hdld.NgayKy.ToString("yyyy-MM-dd") + "', " +
    "N'" + hdld.NoiDung + "', " +    hdld.LanKy + ", " +    hdld.ThoiHan + ", " +    hdld.HeSoLuong + ", " +
    hdld.IdNhanVien + ", " +    "N'" + hdld.Created_By + "', " +    "'" + hdld.Created_Date + "', " + "null, null)";
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            
            
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Update(HDLaoDong hdld) 
        {
            string sql = @"UPDATE HopDong 
                           SET NgayBatDau = "+ hdld.NgayBatDau + ",  NgayKetThuc = "+ hdld.NgayKetThuc + ", NgayKy = "+hdld.NgayKy+
                           ", NoiDung = "+ hdld.NoiDung + ",  LanKy = "+hdld.LanKy+", ThoiHan = "+hdld.ThoiHan
                           +", HeSoLuong = "+hdld.HeSoLuong+", IdNhanVien = "+hdld.IdNhanVien+", Updated_By = "+ hdld.Updated_By
                           +",  Updated_Date = "+hdld.Updated_Date+"   WHERE SoHD = "+ hdld.SoHD;
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Delete(string soHD, int deletedBy)
        {
            string sql = @"UPDATE HopDong
                   SET Deleted_By = "+deletedBy+",  Deleted_Date = "+DateTime.Now+"   WHERE SoHD = "+soHD;
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
