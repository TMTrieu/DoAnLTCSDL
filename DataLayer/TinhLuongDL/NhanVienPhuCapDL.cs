using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class NhanVienPhuCapDL : DataProvider
    {
        public List<NhanVienPhuCap> GetNhanVienPhuCaps()
        {
            List<NhanVienPhuCap> list = new List<NhanVienPhuCap>();
            string sql = @"
                SELECT nvpc.*, nv.HoTen, cv.TenChucVu, pc.TenPhuCap
                FROM NhanVienPhuCap nvpc
                JOIN NhanVien nv ON nvpc.IdNhanVien = nv.IdNhanVien
                JOIN ChucVu cv ON nv.IdChucVu = cv.IdChucVu
                JOIN PhuCap pc ON nvpc.IdPhuCap = pc.IdPhuCap
                WHERE nvpc.Deleted_By IS NULL OR nvpc.Deleted_By IS NULL";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    NhanVienPhuCap nvpc = new NhanVienPhuCap
                    {
                        IdNhanVienPhuCap = Convert.ToInt32(reader["IdNhanVienPhuCap"]),
                        IdNhanVien = Convert.ToInt32(reader["IdNhanVien"]),
                        IdPhuCap = Convert.ToInt32(reader["IdPhuCap"]),
                        HoTen = reader["HoTen"].ToString(),
                        TenChucVu = reader["TenChucVu"].ToString(),
                        TenPhuCap = reader["TenPhuCap"].ToString(),
                        Ngay = Convert.ToDateTime(reader["Ngay"]),
                        NoiDung = reader["NoiDung"].ToString(),
                        SoTien = float.Parse(reader["SoTien"].ToString()),
                        Created_By = reader["Created_By"] as int?,
                        Created_Date = reader["Created_Date"] as DateTime?,
                        Updated_By = reader["Updated_By"] as int?,
                        Updated_Date = reader["Updated_Date"] as DateTime?,
                        Deleted_By = reader["Deleted_By"] as int?,
                        Deleted_Date = reader["Deleted_Date"] as DateTime?
                    };
                    list.Add(nvpc);
                }
                reader.Close();
                return list;
            }
            finally
            {
                DisConnect();
            }
        }

        public int GetAvailableId()
        {
            string sql = @"
        SELECT ISNULL(MIN(a.IdNhanVienPhuCap + 1), 1) AS NextID
        FROM NhanVienPhuCap a
        LEFT JOIN NhanVienPhuCap b ON a.IdNhanVienPhuCap + 1 = b.IdNhanVienPhuCap
        WHERE b.IdNhanVienPhuCap IS NULL";

            object result = MyExecuteScalar(sql, CommandType.Text);
            return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 1;
        }


        public bool Add(NhanVienPhuCap nvpc)
        {
            string sql = @"
                INSERT INTO NhanVienPhuCap(IdNhanVienPhuCap, IdNhanVien, IdPhuCap, Ngay, NoiDung, SoTien, Created_By, Created_Date)
                VALUES (@IdNhanVienPhuCap, @IdNhanVien, @IdPhuCap, @Ngay, @NoiDung, @SoTien, @Created_By, @Created_Date)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdNhanVienPhuCap", nvpc.IdNhanVienPhuCap),
                new SqlParameter("@IdNhanVien", nvpc.IdNhanVien),
                new SqlParameter("@IdPhuCap", nvpc.IdPhuCap),
                new SqlParameter("@Ngay", nvpc.Ngay),
                new SqlParameter("@NoiDung", nvpc.NoiDung ?? ""),
                new SqlParameter("@SoTien", nvpc.SoTien),
                new SqlParameter("@Created_By", nvpc.Created_By ?? (object)DBNull.Value),
                new SqlParameter("@Created_Date", nvpc.Created_Date ?? DateTime.Now)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }

        public bool Update(NhanVienPhuCap nvpc)
        {
            string sql = @"
                UPDATE NhanVienPhuCap SET
                    IdNhanVien = @IdNhanVien,
                    IdPhuCap = @IdPhuCap,
                    Ngay = @Ngay,
                    NoiDung = @NoiDung,
                    SoTien = @SoTien,
                    Updated_By = @Updated_By,
                    Updated_Date = @Updated_Date
                WHERE IdNhanVienPhuCap = @IdNhanVienPhuCap";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdNhanVienPhuCap", nvpc.IdNhanVienPhuCap),
                new SqlParameter("@IdNhanVien", nvpc.IdNhanVien),
                new SqlParameter("@IdPhuCap", nvpc.IdPhuCap),
                new SqlParameter("@Ngay", nvpc.Ngay),
                new SqlParameter("@NoiDung", nvpc.NoiDung ?? ""),
                new SqlParameter("@SoTien", nvpc.SoTien),
                new SqlParameter("@Updated_By", nvpc.Updated_By ?? (object)DBNull.Value),
                new SqlParameter("@Updated_Date", nvpc.Updated_Date ?? DateTime.Now)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }

        public bool Delete(int id, int? deletedBy = null)
        {
            string sql = @"
                UPDATE NhanVienPhuCap SET
                    Deleted_By = @Deleted_By,
                    Deleted_Date = @Deleted_Date
                WHERE IdNhanVienPhuCap = @IdNhanVienPhuCap";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Deleted_By", deletedBy ?? (object)DBNull.Value),
                new SqlParameter("@Deleted_Date", DateTime.Now),
                new SqlParameter("@IdNhanVienPhuCap", id)
            };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }
    }
}
