using System;
using System.Data;
using System.Data.SqlClient;
using TransferObject.TinhLuong;
using System.Collections.Generic;
using TransferObject;
using System.ComponentModel.Design;

namespace DataLayer
{
    public class BangLuongDL : DataProvider
    {
        public BangLuong GetItem(int maKyCong, int idNhanVien)
        {
            BangLuong result = null;
            string sql = "SELECT * FROM BangLuong WHERE MaKyCong = " + maKyCong + " AND IdNhanVien = " + idNhanVien;

            try
            {
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                {
                    result = new BangLuong
                    {
                        IdBangLuong = Convert.ToInt32(dr["IdBangLuong"]),
                        MaKyCong = Convert.ToInt32(dr["MaKyCong"]),
                        IdNhanVien = Convert.ToInt32(dr["IdNhanVien"]),
                        HoTen = dr["HoTen"].ToString(),
                        NgayCongTrongThang = Convert.ToInt32(dr["NgayCongTrongThang"]),
                        NgayPhep = Convert.ToDouble(dr["NgayPhep"]),
                        KhongPhep = Convert.ToDouble(dr["KhongPhep"]),
                        NgayLe = Convert.ToDouble(dr["NgayLe"]),
                        NgayChuNhat = Convert.ToDouble(dr["NgayChuNhat"]),
                        NgayThuong = Convert.ToDouble(dr["NgayThuong"]),
                        TangCa = Convert.ToDouble(dr["TangCa"]),
                        PhuCap = Convert.ToDouble(dr["PhuCap"]),
                        ThucLanh = Convert.ToDouble(dr["ThucLanh"]),
                        Created_By = dr["Created_By"] as int?,
                        Created_Date = dr["Created_Date"] as DateTime?,
                        Updated_By = dr["Updated_By"] as int?,
                        Updated_Date = dr["Updated_Date"] as DateTime?,
                        Deleted_By = dr["Deleted_By"] as int?,
                        Deleted_Date = dr["Deleted_Date"] as DateTime?
                    };
                }
                dr.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy bảng lương: " + ex.Message);
            }
            finally { DisConnect(); }
        }

        public List<BangLuong> GetListByMaKyCong(int maKyCong)
        {
            List<BangLuong> list = new List<BangLuong>();
            

            string sql = "Select * FROM BangLuong WHERE MaKyCong =" + maKyCong; 
            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    BangLuong bl = new BangLuong
                    {
                        IdBangLuong = dr["IdBangLuong"] != DBNull.Value ? Convert.ToInt32(dr["IdBangLuong"]) : 0,
                        MaKyCong = dr["MaKyCong"] != DBNull.Value ? Convert.ToInt32(dr["MaKyCong"]) : 0,
                        IdNhanVien = dr["IdNhanVien"] != DBNull.Value ? Convert.ToInt32(dr["IdNhanVien"]) : 0,
                        HoTen = dr["HoTen"] != DBNull.Value ? dr["HoTen"].ToString() : string.Empty,
                        NgayCongTrongThang = dr["NgayCongTrongThang"] != DBNull.Value ? Convert.ToInt32(dr["NgayCongTrongThang"]) : 0,
                        NgayPhep = dr["NgayPhep"] != DBNull.Value ? Convert.ToDouble(dr["NgayPhep"]) : 0,
                        KhongPhep = dr["KhongPhep"] != DBNull.Value ? Convert.ToDouble(dr["KhongPhep"]) : 0,
                        NgayLe = dr["NgayLe"] != DBNull.Value ? Convert.ToDouble(dr["NgayLe"]) : 0,
                        NgayChuNhat = dr["NgayChuNhat"] != DBNull.Value ? Convert.ToDouble(dr["NgayChuNhat"]) : 0,
                        NgayThuong = dr["NgayThuong"] != DBNull.Value ? Convert.ToDouble(dr["NgayThuong"]) : 0,
                        TangCa = dr["TangCa"] != DBNull.Value ? Convert.ToDouble(dr["TangCa"]) : 0,
                        PhuCap = dr["PhuCap"] != DBNull.Value ? Convert.ToDouble(dr["PhuCap"]) : 0,
                        ThucLanh = dr["ThucLanh"] != DBNull.Value ? Convert.ToDouble(dr["ThucLanh"]) : 0,
                        Created_By = dr["Created_By"] as int?,
                        Created_Date = dr["Created_Date"] as DateTime?,
                        Updated_By = dr["Updated_By"] as int?,
                        Updated_Date = dr["Updated_Date"] as DateTime?,
                        Deleted_By = dr["Deleted_By"] as int?
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

        public bool TinhLuongNhanVien(int maKyCong)
        {
            try
            {
                Connect();
        /// Lấy số ngày công trong tháng
        string sqlKC = $"SELECT SoNgayCong FROM KyCong WHERE MaKyCong = {maKyCong}"; ;
                SqlDataReader drKC = MyExecuteReader(sqlKC, CommandType.Text);
                if (!drKC.Read())
                {
                    drKC.Close();
                    return false;
                }
                double ngayCongTrongThang = Convert.ToDouble(drKC["SoNgayCong"]);
                drKC.Close();


                // Lấy danh sách nhân viên trong kỳ công
                string sqlNV = $@"
            SELECT DISTINCT nv.IdNhanVien, nv.HoTen 
            FROM NhanVien nv
            JOIN KyCongChiTiet kcct ON kcct.IdNhanVien = nv.IdNhanVien
            WHERE kcct.MaKyCong = {maKyCong} AND nv.Deleted_By = 0";

    SqlDataReader drNV = MyExecuteReader(sqlNV, CommandType.Text);


                while (drNV.Read())
                {
                    int idNhanVien = Convert.ToInt32(drNV["IdNhanVien"]);
    string hoTen = drNV["HoTen"].ToString();

    // Lấy hợp đồng mới nhất
    string sqlHD = $@"
                SELECT TOP 1 * 
                FROM HopDong 
                WHERE IdNhanVien = {idNhanVien} AND Deleted_By = 0 
                ORDER BY NgayKy DESC";

    SqlDataReader drHD = MyExecuteReader(sqlHD, CommandType.Text);


                    if (!drHD.Read())
                    {
                        drHD.Close();
                        continue;
                    }

double heSoLuong = Convert.ToDouble(drHD["HeSoLuong"]);
double luongCoBan = Convert.ToDouble(drHD["LuongCoBan"]);
drHD.Close();

double luong1NgayCong = (luongCoBan * heSoLuong) / ngayCongTrongThang;

// Lấy dữ liệu từ KyCongChiTiet
string sqlCong = $@"
                SELECT * 
                FROM KyCongChiTiet 
                WHERE MaKyCong = {maKyCong} AND IdNhanVien = {idNhanVien}";

SqlDataReader drCong = MyExecuteReader(sqlCong, CommandType.Text);


if (!drCong.Read())
{
    drCong.Close();
    continue;
}
double tongNgayCong = Convert.ToDouble(drCong["TongNgayCong"]);
double ngayPhep = Convert.ToDouble(drCong["NgayPhep"]);
double khongPhep = Convert.ToDouble(drCong["NghiKhongPhep"]);
double ngayLe = Convert.ToDouble(drCong["CongNgayLe"]);
double ngayChuNhat = Convert.ToDouble(drCong["CongNgayNghi"]);
drCong.Close();

// Tính lương từng phần
double luongNgayThuong = tongNgayCong * luong1NgayCong;
double luongPhep = ngayPhep * luong1NgayCong * 0.3;
double luongLe = ngayLe * luong1NgayCong * 3;
double luongCN = ngayChuNhat * luong1NgayCong * 2;

// Tính phụ cấp (SoTien * luong1NgayCong)
string sqlPhuCap = $@"
                SELECT ISNULL(SUM(SoTien), 0) AS TongSoTien 
                FROM NhanVien_PhuCap 
                WHERE IdNhanVien = {idNhanVien}";

SqlDataReader drPC = MyExecuteReader(sqlPhuCap, CommandType.Text);


double tongPhuCap = 0;
if (drPC.Read())
{
    double tongSoTien = Convert.ToDouble(drPC["TongSoTien"]);
    tongPhuCap = tongSoTien;
}
drPC.Close();

// Tính lương tăng ca từ bảng TangCa: MaKyCong = Nam * 100 + Thang
string sqlTangCa = $@"
                SELECT ISNULL(SUM(SoGio * HeSo), 0) AS TongSoGio
                FROM TangCa 
                WHERE IdNhanVien = {idNhanVien} AND MaKyCong = {maKyCong}";

SqlDataReader drTC = MyExecuteReader(sqlTangCa, CommandType.Text);


double luongTangCa = 0;
if (drTC.Read())
{
    double gioHeSo = Convert.ToDouble(drTC["TongSoGio"]);
    luongTangCa = gioHeSo;
}
drTC.Close();



double thucLanh = luongNgayThuong + luongPhep + luongLe + luongCN + luongTangCa + tongPhuCap;

// Lưu vào BangLuong
string sqlInsert = @"
            INSERT INTO BangLuong 
            (MaKyCong, IdNhanVien, HoTen, NgayCongTrongThang, NgayPhep, KhongPhep, NgayLe, NgayChuNhat, NgayThuong, TangCa, PhuCap, ThucLanh, Created_By, Created_Date, DaXoa) 
            VALUES 
            (@MaKyCong, @IdNhanVien, @HoTen, @NgayCongTrongThang, @NgayPhep, @KhongPhep, @NgayLe, @NgayChuNhat, @NgayThuong, @TangCa, @PhuCap, @ThucLanh, @Created_By, @Created_Date, 0)";

List<SqlParameter> insertParams = new List<SqlParameter>
            {
                new SqlParameter("@MaKyCong", maKyCong),
                new SqlParameter("@IdNhanVien", idNhanVien),
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@NgayCongTrongThang", ngayCongTrongThang),
                new SqlParameter("@NgayPhep", ngayPhep),
                new SqlParameter("@KhongPhep", khongPhep),
                new SqlParameter("@NgayLe", ngayLe),
                new SqlParameter("@NgayChuNhat", ngayChuNhat),
                new SqlParameter("@NgayThuong", tongNgayCong), // số ngày công
                new SqlParameter("@TangCa", luongTangCa),
                new SqlParameter("@PhuCap", tongPhuCap),
                new SqlParameter("@ThucLanh", thucLanh),
                new SqlParameter("@Created_By", 1),
                new SqlParameter("@Created_Date", DateTime.Now)
            };

MyExecuteNonQuery(sqlInsert, CommandType.Text, insertParams);
                }

                drNV.Close();
return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tính lương nhân viên: " + ex.Message);
            }
            finally
            {
    DisConnect();
}
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
            new SqlParameter("@KhongPhep", bl.KhongPhep),
            new SqlParameter("@NgayLe", bl.NgayLe),
            new SqlParameter("@NgayChuNhat", bl.NgayChuNhat),
            new SqlParameter("@NgayThuong", bl.NgayThuong),
            new SqlParameter("@TangCa", bl.TangCa),
            new SqlParameter("@PhuCap", bl.PhuCap),
            new SqlParameter("@ThucLanh", bl.ThucLanh),
            new SqlParameter("@Created_By", bl.Created_By ?? (object)DBNull.Value),
            new SqlParameter("@Created_Date", bl.Created_Date ?? DateTime.Now)
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
    new SqlParameter("@KhongPhep", bl.KhongPhep),
    new SqlParameter("@NgayLe", bl.NgayLe),
    new SqlParameter("@NgayChuNhat", bl.NgayChuNhat),
    new SqlParameter("@NgayThuong", bl.NgayThuong),
    new SqlParameter("@TangCa", bl.TangCa),
    new SqlParameter("@PhuCap", bl.PhuCap),
    new SqlParameter("@ThucLanh", bl.ThucLanh),
    new SqlParameter("@Updated_By", bl.Updated_By ?? (object)DBNull.Value),
    new SqlParameter("@Updated_Date", bl.Updated_Date ?? DateTime.Now)
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



    }
}
