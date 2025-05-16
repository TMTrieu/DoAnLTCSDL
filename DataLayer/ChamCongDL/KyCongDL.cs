using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer.QuanLyChamCongDL
{
    public class KyCongDL:DataProvider
    {
            public List<KyCong> GetKyCongs()
            {
                List<KyCong> kyCongs = new List<KyCong>();
                string sql = "SELECT * FROM KyCong";
            int maKyCong;
            int thang;
            int nam;
            bool khoa;
            DateTime ngayTinhCong;
            double soNgayCong;
            bool trangThai;
                try
                {
                    Connect();
                    SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);

                    while (dr.Read())
                    {
                    maKyCong = int.Parse(dr[0].ToString());
                    thang = int.Parse(dr[1].ToString());
                    nam = int.Parse(dr[2].ToString());
                    khoa = bool.Parse(dr["Khoa"].ToString());
                    ngayTinhCong = DateTime.Parse(dr[4].ToString());
                    soNgayCong = double.Parse(dr[5].ToString());
                    trangThai = bool.Parse(dr[6].ToString());

                        KyCong kyCong = new KyCong(maKyCong, thang,nam, khoa, ngayTinhCong, soNgayCong, trangThai);
                        kyCongs.Add(kyCong);
                    }

                    dr.Close();
                    return kyCongs;
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
            public bool AddKyCong(KyCong kyCong)
            {
                string sql = "INSERT INTO KyCong VALUES (" + kyCong.MaKyCong + ", " +  kyCong.Thang + ", " +   kyCong.Nam + ", " +
                 (kyCong.Khoa ? 1 : 0) + ", '" +
                 kyCong.NgayTinhCong.ToString("yyyy-MM-dd") + "', " +
                 kyCong.SoNgayCong + ", " +
                 (kyCong.TrangThai ? 1 : 0) + ")";

            try
                {
                    int result = MyExecuteNonQuery(sql, CommandType.Text);
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                
            }

            public bool UpdateKyCong(KyCong kyCong)
            {
                string sql = "UPDATE KyCong SET " +
                 "MaKyCong = " + kyCong.MaKyCong + ", " +
                 "Thang = " + kyCong.Thang + ", " +
                 "Nam = " + kyCong.Nam + ", " +
                 "Khoa = " + (kyCong.Khoa ? 1 : 0) + ", " +
                 "NgayTinhCong = '" + kyCong.NgayTinhCong.ToString("yyyy-MM-dd") + "', " +
                 "SoNgayCong = " + kyCong.SoNgayCong + ", " +
                 "TrangThai = " + (kyCong.TrangThai ? 1 : 0) +
                 " WHERE MaKyCong = " + kyCong.MaKyCong;
            try
                {
                    int result = MyExecuteNonQuery(sql, CommandType.Text);
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                
            }

            public bool DeleteKyCong(int id)
            {
                string sql = "DELETE FROM KyCong WHERE MaKyCong =" + id;

                try
                {
                    int result = MyExecuteNonQuery(sql, CommandType.Text);
                    return result > 0;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
               

            }
        }
    }
