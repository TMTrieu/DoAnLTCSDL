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

            int id;
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
                    SqlDataReader dr = MyExcuteReader(sql, CommandType.Text);

                    while (dr.Read())
                    {
                        id = int.Parse(dr[0].ToString());
                    maKyCong = int.Parse(dr[1].ToString());
                    thang = int.Parse(dr[2].ToString());
                    nam = int.Parse(dr[3].ToString());
                    khoa = bool.Parse(dr[4].ToString());
                    ngayTinhCong = DateTime.Parse(dr[5].ToString());
                    soNgayCong = double.Parse(dr[6].ToString());
                    trangThai = bool.Parse(dr[7].ToString());

                        KyCong kyCong = new KyCong(id,maKyCong, thang,nam, khoa, ngayTinhCong, soNgayCong, trangThai);
                        kyCongs.Add(kyCong);
                    }

                    dr.Close();
                    return kyCongs;
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
            public bool AddKyCong(KyCong kyCong)
            {
                string sql = "INSERT INTO KyCong VALUES (" + kyCong.ID + ", " + kyCong.MaKyCong + ", " +  kyCong.Thang + ", " +   kyCong.Nam + ", " +
                 (kyCong.Khoa ? 1 : 0) + ", '" +
                 kyCong.NgayTinhCong.ToString("dd-MM-yyyy") + "', " +
                 kyCong.SoNgayCong + ", " +
                 (kyCong.TrangThai ? 1 : 0) + ")";

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
                 " WHERE ID = " + kyCong.ID;
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

            public bool DeleteKyCong(int id)
            {
                string sql = "DELETE FROM KyCong WHERE ID =" + id;

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
        }
    }
