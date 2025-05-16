using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataLayer
{
    public class TangCaDL : DataProvider
    {
        public List<TangCa> GetTangCas()
        {
            List<TangCa> list = new List<TangCa>();
            string sql = @"
            SELECT tc.*, nv.HoTen, lc.TenLoaiCa, lc.HeSo
FROM TangCa tc
LEFT JOIN NhanVien nv ON tc.IdNhanVien = nv.IdNhanVien
LEFT JOIN LoaiCa lc ON tc.IdLoaiCa = lc.IdLoaiCa
WHERE tc.Deleted_Date IS NULL";

            try
            {
                Connect();
                SqlDataReader dr = MyExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    int idTangCa = dr["IdTangCa"] != DBNull.Value ? Convert.ToInt32(dr["IdTangCa"]) : 0;
                    DateTime ngayTangCa = dr["NgayTangCa"] != DBNull.Value ? Convert.ToDateTime(dr["NgayTangCa"]) : DateTime.MinValue;
                    float soGio = dr["SoGio"] != DBNull.Value ? float.Parse(dr["SoGio"].ToString()) : 0f;
                    float? soTien = dr["SoTien"] != DBNull.Value ? (float?)float.Parse(dr["SoTien"].ToString()) : null;
                    int idNhanVien = dr["IdNhanVien"] != DBNull.Value ? Convert.ToInt32(dr["IdNhanVien"]) : 0;
                    string hoTen = dr["HoTen"] != DBNull.Value ? dr["HoTen"].ToString() : "";
                    int idLoaiCa = dr["IdLoaiCa"] != DBNull.Value ? Convert.ToInt32(dr["IdLoaiCa"]) : 0;
                    string tenLoaiCa = dr["TenLoaiCa"] != DBNull.Value ? dr["TenLoaiCa"].ToString() : "";
                    float heSo = dr["HeSo"] != DBNull.Value ? float.Parse(dr["HeSo"].ToString()) : 0f;
                    string ghiChu = dr["GhiChu"] != DBNull.Value ? dr["GhiChu"].ToString() : "";

                    int? createdBy = dr["Created_By"] != DBNull.Value ? (int?)Convert.ToInt32(dr["Created_By"]) : null;
                    DateTime? createdDate = dr["Created_Date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["Created_Date"]) : null;
                    int? updatedBy = dr["Updated_By"] != DBNull.Value ? (int?)Convert.ToInt32(dr["Updated_By"]) : null;
                    DateTime? updatedDate = dr["Updated_Date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["Updated_Date"]) : null;
                    int? deletedBy = dr["Deleted_By"] != DBNull.Value ? (int?)Convert.ToInt32(dr["Deleted_By"]) : null;
                    DateTime? deletedDate = dr["Deleted_Date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["Deleted_Date"]) : null;

                    TangCa tc = new TangCa(
                        idTangCa, ngayTangCa, soGio, soTien,
                        idNhanVien, hoTen, idLoaiCa, tenLoaiCa,
                        heSo, ghiChu, createdBy, createdDate,
                        updatedBy, updatedDate, deletedBy, deletedDate
                    );

                    list.Add(tc);
                }
                dr.Close();
                return list;
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



        public bool Add(TangCa tc)
        {
            string sql = @"
        INSERT INTO TangCa (NgayTangCa, SoGio, IdNhanVien, IdLoaiCa, HeSo, SoTien, GhiChu, Created_By, Created_Date)
        VALUES (@NgayTangCa, @SoGio, @IdNhanVien, @IdLoaiCa, @HeSo, @SoTien, @GhiChu, @Created_By, @Created_Date)";

            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@NgayTangCa", tc.NgayTangCa),
        new SqlParameter("@SoGio", tc.SoGio),
        new SqlParameter("@IdNhanVien", tc.IdNhanVien),
        new SqlParameter("@IdLoaiCa", tc.IdLoaiCa),
        new SqlParameter("@HeSo", tc.HeSo),
        new SqlParameter("@SoTien", tc.SoTien),
        new SqlParameter("@GhiChu", tc.GhiChu ?? ""),
        new SqlParameter("@Created_By", tc.Created_By ?? (object)DBNull.Value),
        new SqlParameter("@Created_Date", tc.Created_Date ?? DateTime.Now)
    };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }


        public bool Update(TangCa tc)
        {
            string sql = @"
        UPDATE TangCa SET
            NgayTangCa = @NgayTangCa,
            SoGio = @SoGio,
            IdNhanVien = @IdNhanVien,
            IdLoaiCa = @IdLoaiCa,
            HeSo = @HeSo,
            SoTien = @SoTien,
            GhiChu = @GhiChu,
            Updated_By = @Updated_By,
            Updated_Date = @Updated_Date
        WHERE IdTangCa = @IdTangCa";

            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@NgayTangCa", tc.NgayTangCa),
        new SqlParameter("@SoGio", tc.SoGio),
        new SqlParameter("@IdNhanVien", tc.IdNhanVien),
        new SqlParameter("@IdLoaiCa", tc.IdLoaiCa),
        new SqlParameter("@HeSo", tc.HeSo),
        new SqlParameter("@SoTien", tc.SoTien),
        new SqlParameter("@GhiChu", tc.GhiChu ?? ""),
        new SqlParameter("@Updated_By", tc.Updated_By ?? (object)DBNull.Value),
        new SqlParameter("@Updated_Date", tc.Updated_Date ?? DateTime.Now),
        new SqlParameter("@IdTangCa", tc.IdTangCa)
    };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }


        public bool Delete(int id, int? deletedBy = null)
        {
            string sql = @"
        UPDATE TangCa SET 
            Deleted_By = @Deleted_By,
            Deleted_Date = @Deleted_Date
        WHERE IdTangCa = @IdTangCa";

            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@Deleted_By", deletedBy ?? (object)DBNull.Value),
        new SqlParameter("@Deleted_Date", DateTime.Now),
        new SqlParameter("@IdTangCa", id)
    };

            return MyExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        }

    }
}
