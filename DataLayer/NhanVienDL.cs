using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Security.Cryptography;

namespace DataLayer
{
    public class NhanVienDL : DataProvider
    {
        public List<NhanVien> GetNhanViens()
        {
            int idNhanVien, idPhongBan, idBoPhan, idChucVu, idTrinhDo, idDanToc, idTonGiao;
            string name, phone, address, cccd;
            bool gender;
            DateTime dateOfBirth;
            byte[] picture;
            List<NhanVien> nhanviens = new List<NhanVien>();

            string sql = @"SELECT nv.IdNhanVien, nv.HoTen, nv.GioiTinh, nv.NgaySinh, 
                          nv.DienThoai, nv.CanCuocCongDan, nv.DiaChi, nv.HinhAnh,
                          pb.IdPhongBan, pb.TenPhongBan,
                          bp.IdBoPhan, bp.TenBoPhan,
                          cv.IdChucVu, cv.TenChucVu,
                          td.IdTrinhDo, td.TenTrinhDo,
                          dt.IdDanToc, dt.TenDanToc,
                          tg.IdTonGiao, tg.TenTonGiao
                  FROM NhanVien nv
                  LEFT JOIN PhongBan pb ON nv.IdPhongBan = pb.IdPhongBan
                  LEFT JOIN BoPhan bp ON nv.IdBoPhan = bp.IdBoPhan
                  LEFT JOIN ChucVu cv ON nv.IdChucVu = cv.IdChucVu
                  LEFT JOIN TrinhDo td ON nv.IdTrinhDo = td.IdTrinhDo
                  LEFT JOIN DanToc dt ON nv.IdDanToc = dt.IdDanToc
                  LEFT JOIN TonGiao tg ON nv.IdTonGiao = tg.IdTonGiao WHERE DaThoiViec=0";
            try
            {
                Connect();
                SqlDataReader reader = MyExcuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    idNhanVien = int.Parse(reader["IdNhanVien"].ToString());
                    name = reader["HoTen"].ToString();
                    gender = (bool)reader["GioiTinh"];
                    dateOfBirth = (DateTime)reader["NgaySinh"];
                    phone = reader["DienThoai"].ToString();
                    cccd = reader["CanCuocCongDan"].ToString();
                    address = reader["DiaChi"].ToString();
                    picture = reader["HinhAnh"] == DBNull.Value ? null : (byte[])reader["HinhAnh"];

                    idPhongBan = int.Parse(reader["IdPhongBan"].ToString());
                    string tenPhongBan = reader["TenPhongBan"].ToString();

                    idBoPhan = int.Parse(reader["IdBoPhan"].ToString());
                    string tenBoPhan = reader["TenBoPhan"].ToString();

                    idChucVu = int.Parse(reader["IdChucVu"].ToString());
                    string tenChucVu = reader["TenChucVu"].ToString();

                    idTrinhDo = int.Parse(reader["IdTrinhDo"].ToString());
                    string tenTrinhDo = reader["TenTrinhDo"].ToString();

                    idDanToc = int.Parse(reader["IdDanToc"].ToString());
                    string tenDanToc = reader["TenDanToc"].ToString();

                    idTonGiao = int.Parse(reader["IdTonGiao"].ToString());
                    string tenTonGiao = reader["TenTonGiao"].ToString();
                    // Sử dụng constructor đầy đủ với cả ID và tên
                    NhanVien nhanvien = new NhanVien(
                        idNhanVien, name, gender, dateOfBirth, phone, cccd, address, picture,
                        idPhongBan, tenPhongBan,
                        idBoPhan, tenBoPhan,
                        idChucVu, tenChucVu,
                        idTrinhDo, tenTrinhDo,
                        idDanToc, tenDanToc,
                        idTonGiao, tenTonGiao);

                    nhanviens.Add(nhanvien);
                }
                reader.Close();
                return nhanviens;
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

        public bool Add(NhanVien nv)
        {
            string sql = "INSERT INTO NhanVien VALUES (" +
         nv.IdNhanVien + ", " +
         "N'" + nv.HoTen + "', " +
         (nv.GioiTinh ? 1 : 0) + ", " +
         "'" + nv.NgaySinh.ToString("yyyy-MM-dd") + "', " +
         "'" + nv.DienThoai + "', " +
         "'" + nv.CCCD + "', " +
         "N'" + nv.DiaChi + "', " +
         "@HinhAnh, " +
         nv.IdPhongBan + ", " +
         nv.IdBoPhan + ", " +
         nv.IdChucVu + ", " +
         nv.IdTrinhDo + ", " +
         nv.IdDanToc + ", " +
         nv.IdTonGiao + ", "+0+")";

            List<SqlParameter> parameters = new List<SqlParameter>();
            
            if (nv.HinhAnh != null)
                parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarBinary) { Value = nv.HinhAnh });
            else
                parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarBinary) { Value = DBNull.Value });
            try
            {
                int result = MyExecuteNonQuery(sql, CommandType.Text,  parameters);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                  
        }
        public bool Update(NhanVien nv)
        {
            
            string sql = "UPDATE NhanVien SET " +
    "HoTen = N'" + nv.HoTen + "', " +
    "GioiTinh = " + (nv.GioiTinh ? 1 : 0) + ", " +
    "NgaySinh = '" + nv.NgaySinh.ToString("yyyy-MM-dd") + "', " + 
    "DienThoai = '" + nv.DienThoai + "', " +    "CanCuocCongDan = '" + nv.CCCD + "', " +     "DiaChi = N'" + nv.DiaChi + "', " +
    "HinhAnh = " + "@HinhAnh" + ", " +    "IdPhongBan = " + nv.IdPhongBan + ", " +     "IdBoPhan = " + nv.IdBoPhan + ", " + 
    "IdChucVu = " + nv.IdChucVu + ", " +     "IdTrinhDo = " + nv.IdTrinhDo + ", " +     "IdDanToc = " + nv.IdDanToc + ", " + 
    "IdTonGiao = " + nv.IdTonGiao + " " +     "WHERE IdNhanVien = " + nv.IdNhanVien;
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (nv.HinhAnh != null)
                parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarBinary) { Value = nv.HinhAnh });
            else
                parameters.Add(new SqlParameter("@HinhAnh", SqlDbType.VarBinary) { Value = DBNull.Value });
            try
            {
                
                int result = MyExecuteNonQuery(sql, CommandType.Text, parameters);
                return result > 0;
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
        }
        public bool Delete(int id)
        {
            string sql = "DELETE FROM NhanVien WHERE IdNhanVien = "+id;
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
