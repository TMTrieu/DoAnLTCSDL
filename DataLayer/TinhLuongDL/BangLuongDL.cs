using System;
using System.Data;
using System.Data.SqlClient;
using TransferObject.TinhLuong;
using System.Collections.Generic;

namespace DataLayer
{
    public class BangLuongDL : DataProvider
    {
        public BangLuong GetItem(int maKyCong, int idNhanVien)
        {
            BangLuong bangLuong;
            string sql = $"SELECT * FROM BangLuong WHERE MaKyCong = {maKyCong} AND IdNhanVien = {idNhanVien}";

            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                {
                    bangLuong = new BangLuong
                    {
                        IdBangLuong = Convert.ToInt32(dr["IdBangLuong"]),
                        MaKyCong = Convert.ToInt32(dr["MaKyCong"]),
                        IdNhanVien = Convert.ToInt32(dr["IdNhanVien"]),
                        HoTen = dr["HoTen"].ToString(),
                        NgayCongTrongThang = Convert.ToSingle(dr["NgayCongTrongThang"]),
                        NgayPhep = Convert.ToSingle(dr["NgayPhep"]),

                        CongNgayLe = Convert.ToSingle(dr["NgayLe"]),
                        CongNgayNghi = Convert.ToSingle(dr["NgayChuNhat"]),
                        TongNgayCong = Convert.ToSingle(dr["NgayThuong"]),
                        TangCa = Convert.ToSingle(dr["TangCa"]),
                        PhuCap = Convert.ToSingle(dr["PhuCap"]),
                        ThucLanh = Convert.ToSingle(dr["ThucLanh"]),
                    };
                }
                dr.Close();
                return bangLuong;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy bảng lương: " + ex.Message);
            }
        }

        public List<BangLuong> GetListByMaKyCong(int maKyCong)
        {
            List<BangLuong> list = new List<BangLuong>();
            string sql = $"SELECT * FROM BangLuong WHERE MaKyCong = {maKyCong} ";

            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    BangLuong bl = new BangLuong
                    {
                        IdBangLuong = Convert.ToInt32(dr["IdBangLuong"]),
                        MaKyCong = Convert.ToInt32(dr["MaKyCong"]),
                        IdNhanVien = Convert.ToInt32(dr["IdNhanVien"]),
                        HoTen = dr["HoTen"].ToString(),
                        NgayCongTrongThang = dr["NgayCongTrongThang"] != DBNull.Value ? Convert.ToSingle(dr["NgayCongTrongThang"]) : 0,
                        CongNgayLe = dr["CongNgayLe"] != DBNull.Value ? Convert.ToSingle(dr["CongNgayLe"]) : 0,
                        CongNgayNghi = dr["CongNgayNghi"] != DBNull.Value ? Convert.ToSingle(dr["CongNgayNghi"]) : 0,
                        TongNgayCong = dr["TongNgayCong"] != DBNull.Value ? Convert.ToSingle(dr["TongNgayCong"]) : 0,
                        TangCa = dr["TangCa"] != DBNull.Value ? Convert.ToSingle(dr["TangCa"]) : 0,
                        PhuCap = dr["PhuCap"] != DBNull.Value ? Convert.ToSingle(dr["PhuCap"]) : 0,
                        ThucLanh = dr["ThucLanh"] != DBNull.Value ? Convert.ToSingle(dr["ThucLanh"]) : 0,
                        NgayPhep = dr["NgayPhep"] != DBNull.Value ? Convert.ToSingle(dr["NgayPhep"]) : 0,
                    };
                    list.Add(bl);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách bảng lương: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return list;
        }



        public int Add(BangLuong bl)
        {
            string sql = "sp_BangLuong_Add";

            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@MaKyCong", bl.MaKyCong),
                new SqlParameter("@IdNhanVien", bl.IdNhanVien),
                new SqlParameter("@HoTen", bl.HoTen),
                new SqlParameter("@NgayCongTrongThang", bl.NgayCongTrongThang),
                new SqlParameter("@NgayPhep", bl.NgayPhep),
                new SqlParameter("@CongNgayLe", bl.CongNgayLe),
                new SqlParameter("@CongNgayNghi", bl.CongNgayNghi),
                new SqlParameter("@TongNgayCong", bl.TongNgayCong),
                new SqlParameter("@TangCa", bl.TangCa),
                new SqlParameter("@PhuCap", bl.PhuCap),
                new SqlParameter("@ThucLanh", bl.ThucLanh),
        };

            try
            {
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(BangLuong bl)
        {
            string sql = "sp_BangLuong_Update";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdBangLuong", bl.IdBangLuong),
                new SqlParameter("@MaKyCong", bl.MaKyCong),
                new SqlParameter("@IdNhanVien", bl.IdNhanVien),
                new SqlParameter("@HoTen", bl.HoTen),
                new SqlParameter("@NgayCongTrongThang", bl.NgayCongTrongThang),
                new SqlParameter("@NgayPhep", bl.NgayPhep),
                new SqlParameter("@CongNgayLe", bl.CongNgayLe),
                new SqlParameter("@CongNgayNghi", bl.CongNgayNghi),
                new SqlParameter("@TongNgayCong", bl.TongNgayCong),
                new SqlParameter("@TangCa", bl.TangCa),
                new SqlParameter("@PhuCap", bl.PhuCap),
                new SqlParameter("@ThucLanh", bl.ThucLanh)
            };
            try
            {
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM BangLuong WHERE MaKyCong = " + id;
            try
            {
                return MyExecuteNonQuery(sql, CommandType.Text) >0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
