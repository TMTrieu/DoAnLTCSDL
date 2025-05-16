using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class ThongKeHDTheoLoaiDL 
    {
        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyNhanSu;Integrated Security=True";

        public List<ThongKeHDTheoLoai> LayThongKeTheoThoiHanTheoNam(int nam)
        {
            List<ThongKeHDTheoLoai> list = new List<ThongKeHDTheoLoai>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThongKeHopDongTheoThoiHanTheoNam", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nam", nam);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ThongKeHDTheoLoai
                    {
                        LoaiHopDong = reader["LoaiHopDong"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    });
                }
                reader.Close();
            }

            return list;
        }

        public List<string> LayThoiHanTheoNam(int nam)
        {
            List<string> list = new List<string>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_LayThoiHanTheoNam", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nam", nam);

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader["ThoiHan"].ToString());
                }
                reader.Close();
            }

            return list;
        }
        public List<ThongKeHDTheoLoai> LayThongKeTheoNamVaThoiHan(int nam, string thoiHan)
        {
            List<ThongKeHDTheoLoai> list = new List<ThongKeHDTheoLoai>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThongKeTheoNamVaThoiHan", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nam", nam);
                cmd.Parameters.AddWithValue("@ThoiHan", thoiHan); // truyền string

                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ThongKeHDTheoLoai
                    {
                        LoaiHopDong = reader["LoaiHopDong"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SoLuong"])
                    });
                }
                reader.Close();
            }

            return list;
        }




    }
}
