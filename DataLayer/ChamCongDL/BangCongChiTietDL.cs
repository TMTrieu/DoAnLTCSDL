using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer.ChamCongDL
{
    public class BangCongChiTietDL : DataProvider
    {
        public List<BangCongChiTiet> GetBangCongChiTiets(int maKyCong, int idNhanVien)
        {
            List<BangCongChiTiet> list = new List<BangCongChiTiet>();
            string sql = "SELECT BangCongChiTiet.*, TenLoaiCong, TenLoaiCa " +
                        "FROM BangCongChiTiet, LoaiCong, LoaiCa " +
                        "WHERE MaKyCong = " + maKyCong +
                        " AND IdNhanVien = " + idNhanVien;
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                
                while (dr.Read())
                {
                    BangCongChiTiet bangCong = new BangCongChiTiet
                    {
                        IdBangCong = int.Parse(dr["IdBangCong"].ToString()),
                        MaKyCong = int.Parse(dr["MaKyCong"].ToString()),
                        IdNhanVien = int.Parse(dr["IdNhanVien"].ToString()),
                        NgayChamCong = DateTime.Parse(dr["NgayChamCong"].ToString()),
                        IdLoaiCa = int.Parse(dr["IdLoaiCa"].ToString()),
                        IdLoaiCong = int.Parse(dr["IdLoaiCong"].ToString()),
                        ThoiGianVao = TimeSpan.Parse(dr["ThoiGianVao"].ToString()),
                        ThoiGianRa = TimeSpan.Parse(dr["ThoiGianRa"].ToString()),
                        TenLoaiCa = dr["TenLoaiCa"].ToString(),
                        TenLoaiCong = dr["TenLoaiCong"].ToString(),
                        ChamCong = dr["ChamCong"].ToString()
                    };
                    list.Add(bangCong);
                }

                dr.Close();
                return list;
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

        public List<BangCongChiTiet> GetNgayCongChiTiet(int maKyCong, int idNhanVien, DateTime ngayChamCong)
        {
            List<BangCongChiTiet> list = new List<BangCongChiTiet>();
            string sql = "SELECT BangCongChiTiet.*, TenLoaiCong, TenLoaiCa " +
                        "FROM BangCongChiTiet, LoaiCong, LoaiCa " +
                        "WHERE MaKyCong = " + maKyCong +
                        " AND LoaiCong.IdLoaiCong = BangCongChiTiet.IdLoaiCong AND LoaiCa.IdLoaiCa = BangCongChiTiet.IdLoaiCa " +
                        " AND IdNhanVien = " + idNhanVien +
                        " AND NgayChamCong = '" + ngayChamCong.ToString("yyyy-MM-dd") + "'";
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                while (dr.Read())
                {
                    BangCongChiTiet bangCong = new BangCongChiTiet
                    {
                        IdBangCong = int.Parse(dr["IdBangCong"].ToString()),
                        MaKyCong = int.Parse(dr["MaKyCong"].ToString()),
                        IdNhanVien = int.Parse(dr["IdNhanVien"].ToString()),
                        NgayChamCong = DateTime.Parse(dr["NgayChamCong"].ToString()),
                        IdLoaiCa = int.Parse(dr["IdLoaiCa"].ToString()),
                        IdLoaiCong = int.Parse(dr["IdLoaiCong"].ToString()),
                        ThoiGianVao = TimeSpan.Parse(dr["ThoiGianVao"].ToString()),
                        ThoiGianRa = TimeSpan.Parse(dr["ThoiGianRa"].ToString()),
                        TenLoaiCa = dr["TenLoaiCa"].ToString(),
                        TenLoaiCong = dr["TenLoaiCong"].ToString(),
                        ChamCong = dr["ChamCong"].ToString()
                    };
                    list.Add(bangCong);
                }

                dr.Close();
                return list;
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

        public BangCongChiTiet GetCaChiTiet(int maKyCong, int idNhanVien, DateTime ngayChamCong, int loaiCa)
        {
            string sql = "SELECT BangCongChiTiet.*, TenLoaiCong, TenLoaiCa " +
                        "FROM BangCongChiTiet, LoaiCong, LoaiCa " +
                        "WHERE MaKyCong = " + maKyCong + " AND LoaiCong.IdLoaiCong = BangCongChiTiet.IdLoaiCong AND LoaiCa.IdLoaiCa = BangCongChiTiet.IdLoaiCa " +
                        " AND IdNhanVien = " + idNhanVien +
                        " AND NgayChamCong = '" + ngayChamCong.ToString("yyyy-MM-dd") + "' " +
                        " AND BangCongChiTiet.IdLoaiCa = " + loaiCa;
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                if (dr.Read())
                {
                    BangCongChiTiet bangCong = new BangCongChiTiet
                    {
                        IdBangCong = int.Parse(dr["IdBangCong"].ToString()),
                        MaKyCong = int.Parse(dr["MaKyCong"].ToString()),
                        IdNhanVien = int.Parse(dr["IdNhanVien"].ToString()),
                        NgayChamCong = DateTime.Parse(dr["NgayChamCong"].ToString()),
                        IdLoaiCa = int.Parse(dr["IdLoaiCa"].ToString()),
                        IdLoaiCong = int.Parse(dr["IdLoaiCong"].ToString()),
                        ThoiGianVao = TimeSpan.Parse(dr["ThoiGianVao"].ToString()),
                        ThoiGianRa = TimeSpan.Parse(dr["ThoiGianRa"].ToString()),
                        TenLoaiCa = dr["TenLoaiCa"].ToString(),
                        TenLoaiCong = dr["TenLoaiCong"].ToString(),
                        ChamCong = dr["ChamCong"].ToString()
                    };
                    dr.Close();
                    return bangCong;
                }

                dr.Close();
                return null;
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

        public bool AddBangCongChiTiet(BangCongChiTiet bangCong)
        {
            string sql = "INSERT INTO BangCongChiTiet (MaKyCong, IdNhanVien, NgayChamCong, IdLoaiCa, IdLoaiCong, ThoiGianVao, ThoiGianRa, ChamCong) VALUES (" +
    bangCong.MaKyCong + ", " +
    bangCong.IdNhanVien + ", '" +
    bangCong.NgayChamCong.ToString("yyyy-MM-dd") + "', " +
    bangCong.IdLoaiCa + ", " +
    bangCong.IdLoaiCong + ", '" +
    bangCong.ThoiGianVao.ToString(@"hh\:mm\:ss") + "', '" +
    bangCong.ThoiGianRa.ToString(@"hh\:mm\:ss") + "', '" +
    bangCong.ChamCong + "')";


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

        public bool UpdateBangCongChiTiet(BangCongChiTiet bangCong, int id)
        {
            string sql = "UPDATE BangCongChiTiet SET " +
    "MaKyCong = " + bangCong.MaKyCong + ", " +
    "IdNhanVien = " + bangCong.IdNhanVien + ", " +
    "NgayChamCong = '" + bangCong.NgayChamCong.ToString("yyyy-MM-dd") + "', " +
    "IdLoaiCa = " + bangCong.IdLoaiCa + ", " +
    "IdLoaiCong = " + bangCong.IdLoaiCong + ", " +
    "ThoiGianVao = '" + bangCong.ThoiGianVao.ToString(@"hh\:mm\:ss") + "', " +
    "ThoiGianRa = '" + bangCong.ThoiGianRa.ToString(@"hh\:mm\:ss") + "', " +
    "ChamCong = '" + bangCong.ChamCong + "' " +
    "WHERE IdBangCong = " + id;

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

        public bool DeleteBangCongChiTiet(int idBangCong)
        {
            string sql = "DELETE FROM BangCongChiTiet WHERE IdBangCong = " + idBangCong;

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