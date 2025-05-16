using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer.ChamCongDL
{
    public class KyCongChiTietDL : DataProvider
    {
        KyCong kyCong = new KyCong();
        public List<KyCongChiTiet> GetKyCongChiTiets(int maKyCong) 
        {
            string sql = "SELECT KyCongChiTiet.*, NhanVien.HoTen FROM KyCongChiTiet, NhanVien WHERE KyCongChiTiet.MaNhanVien = NhanVien.IdNhanVien and MaKyCong ="+maKyCong;

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                
                List<KyCongChiTiet> danhSach = new List<KyCongChiTiet>();
                while (reader.Read())
                {
                    KyCongChiTiet kyCongChiTiet = new KyCongChiTiet();
                    kyCongChiTiet.ChamCong = new List<string>();
                    kyCongChiTiet.MaKyCong = int.Parse(reader["MaKyCong"].ToString());
                    kyCongChiTiet.MaNhanVien = int.Parse(reader["MaNhanVien"].ToString());
                    kyCongChiTiet.HoTen = reader["HoTen"].ToString();

                    for (int i = 1; i <= 31; i++)
                    {
                        string columnName = "D" + i;
                        if (reader[columnName] != DBNull.Value)
                            kyCongChiTiet.ChamCong.Add(reader[columnName].ToString());
                        else
                            kyCongChiTiet.ChamCong.Add("");
                    }

                    kyCongChiTiet.NgayCong = reader["NgayCong"] != DBNull.Value ? Convert.ToDouble(reader["NgayCong"]) : 0;
                    kyCongChiTiet.NgayPhep = reader["NgayPhep"] != DBNull.Value ? Convert.ToDouble(reader["NgayPhep"]) : 0;
                    kyCongChiTiet.NghiKhongPhep = reader["NghiKhongPhep"] != DBNull.Value ? Convert.ToDouble(reader["NghiKhongPhep"]) : 0;
                    kyCongChiTiet.CongNgayLe = reader["CongNgayLe"] != DBNull.Value ? Convert.ToDouble(reader["CongNgayLe"]) : 0;
                    kyCongChiTiet.CongNgayNghi = reader["CongNgayNghi"] != DBNull.Value ? Convert.ToDouble(reader["CongNgayNghi"]) : 0;
                    kyCongChiTiet.TongNgayCong = reader["TongNgayCong"] != DBNull.Value ? Convert.ToDouble(reader["TongNgayCong"]) : 0;
                    danhSach.Add(kyCongChiTiet);
                }
                reader.Close();

                return danhSach;
            }
            catch (SqlException ex) 
            {
                throw  ex; 
            }
            finally
            {
                DisConnect();
            }
        }
        public void PhatSinhKyCong(int thang, int nam)
        {
            NhanVienDL nhanVienDL = new NhanVienDL();
            List<NhanVien> listNV = nhanVienDL.GetNhanViens();
            int maKyCong = nam * 100 + thang;
            string sqlCheck = "SELECT MaNhanVien FROM KyCongChiTiet WHERE MaKyCong = " + maKyCong;
            List<int> nhanVienDaCoKyCong = new List<int>();

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sqlCheck, CommandType.Text);
                while (reader.Read())
                {
                    nhanVienDaCoKyCong.Add(Convert.ToInt32(reader["MaNhanVien"]));
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

            foreach (NhanVien nv in listNV)
            {
                if (nhanVienDaCoKyCong.Contains(nv.IdNhanVien))
                    continue;
                
            
                List<string> listDay = new List<string>();
                for (int j = 1; j <= DateTime.DaysInMonth(nam, thang); j++)
                {
                    DateTime newDate = new DateTime(nam, thang, j);
                    switch (newDate.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            listDay.Add("CN");
                            break;
                        case "Saturday":
                            listDay.Add("T7");
                            break;
                        default:
                            listDay.Add(null);
                            break;
                    }
                }
                while (listDay.Count < 31)
                {
                    listDay.Add(null);
                }
                KyCongChiTiet kyCongChiTiet = new KyCongChiTiet
                {
                    MaKyCong = maKyCong,
                    MaNhanVien = nv.IdNhanVien,
                    HoTen = nv.HoTen,
                    ChamCong = listDay,
                    NgayCong = 0,
                    NgayPhep = 0,
                    NghiKhongPhep = 0,
                    CongNgayLe = 0,
                    CongNgayNghi = 0,
                    TongNgayCong = 0
                };
                
                for (int i=0;i<31;i++)
                    kyCongChiTiet.ChamCong.Add(listDay[i]);
                string sql = "INSERT INTO KyCongChiTiet values ("+kyCongChiTiet.MaKyCong+","+kyCongChiTiet.MaNhanVien+",";
                for (int i = 0; i < 31; i++)
                {
                    sql += "'" + kyCongChiTiet.ChamCong[i] + "', ";
                }
                sql += kyCongChiTiet.NgayCong + ", " +
                           kyCongChiTiet.NgayPhep + ", " +
                           kyCongChiTiet.NghiKhongPhep + ", " +
                           kyCongChiTiet.CongNgayLe + ", " +
                           kyCongChiTiet.CongNgayNghi + ", " +
                           kyCongChiTiet.TongNgayCong + ")";
                try
                {
                    MyExecuteNonQuery(sql, CommandType.Text);
                }
                catch (Exception ex) { throw ex; }
            }

        }

        public bool CapNhatBangCong(string tenCot,string giatri, int maKyCong, int maNhanVien)
        {
            string sql;
            if(tenCot.StartsWith("D")==false)
            {
                double giaTri = double.Parse(giatri, CultureInfo.InvariantCulture);
                sql = "UPDATE KyCongChiTiet SET " + tenCot + " = " + giaTri + " WHERE MaKyCong =" + maKyCong + " AND MaNhanVien =" + maNhanVien;
                try
                {
                    return (MyExecuteNonQuery(sql, CommandType.Text) > 0);

                }
                catch (SqlException ex) { throw ex; }
            }
            else
            {
                sql = "UPDATE KyCongChiTiet SET " + tenCot + " = '" + giatri + "' WHERE MaKyCong =" + maKyCong + " AND MaNhanVien =" + maNhanVien;
                try
                {
                    return (MyExecuteNonQuery(sql, CommandType.Text) > 0);

                }
                catch (SqlException ex) { throw ex; }
            }
        }
    }
    
}
