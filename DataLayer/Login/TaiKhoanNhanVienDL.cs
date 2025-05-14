using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class TaiKhoanNhanVienDL : DataProvider
    {
        public int GetMaTaiKhoanByUsername(string tenDangNhap)
        {
            string sql = $"SELECT IdNhanVien FROM TaiKhoan WHERE TenDangNhap = N'{tenDangNhap}' AND IsDeleted = 0";
            object result = MyExecuteScalar(sql, CommandType.Text);
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            TaiKhoan tk = null;
            string sql = $"SELECT * FROM TaiKhoan WHERE TenDangNhap = N'{tenDangNhap}' AND MatKhau = N'{matKhau}' AND IsDeleted = 0";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                if (reader.Read())
                {
                    tk = new TaiKhoan
                    {
                        TenDangNhap = reader["TenDangNhap"].ToString(),
                        MatKhau = reader["MatKhau"].ToString(),
                        VaiTro = reader["VaiTro"].ToString(),
                        IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi đăng nhập: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return tk;
        }

        public bool KiemTraTaiKhoan(string tenDangNhap)
        {
            string sql = $"SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = N'{tenDangNhap}'";
            int count = Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text));
            return count > 0;
        }

        public string LayMatKhau(string tenDangNhap)
        {
            string sql = $"SELECT MatKhau FROM TaiKhoan WHERE TenDangNhap = N'{tenDangNhap}'";
            object result = MyExecuteScalar(sql, CommandType.Text);
            return result != null ? result.ToString() : string.Empty;
        }
        public bool DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@TenDangNhap", tenDangNhap),
        new SqlParameter("@MatKhauCu", matKhauCu),
        new SqlParameter("@MatKhauMoi", matKhauMoi)
    };

            int result = MyExecuteNonQuery("sp_DoiMatKhau_TaiKhoanNhanVien", CommandType.StoredProcedure, parameters);
            return result > 0;
        }
    }
}

