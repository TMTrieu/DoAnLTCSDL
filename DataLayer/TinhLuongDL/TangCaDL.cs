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
                    TangCa tc = new TangCa
                    {
                        IdTangCa = Convert.ToInt32(dr["IdTangCa"]),
                        NgayTangCa = Convert.ToDateTime(dr["NgayTangCa"]),
                        SoGio = float.Parse(dr["SoGio"].ToString()),
                        SoTien = float.Parse(dr["SoTien"].ToString()),
                        IdNhanVien = Convert.ToInt32(dr["IdNhanVien"]),
                        HoTen = dr["HoTen"] != DBNull.Value ? dr["HoTen"].ToString() : "",

                        IdLoaiCa = dr["IdLoaiCa"] != DBNull.Value ? Convert.ToInt32(dr["IdLoaiCa"]) : 0,
                        TenLoaiCa = dr["TenLoaiCa"] != DBNull.Value ? dr["TenLoaiCa"].ToString() : "",
                        HeSo = dr["HeSo"] != DBNull.Value ? float.Parse(dr["HeSo"].ToString()) : 0f,

                        GhiChu = dr["GhiChu"] != DBNull.Value ? dr["GhiChu"].ToString() : "",

                        Created_By = dr["Created_By"] != DBNull.Value ? (int?)Convert.ToInt32(dr["Created_By"]) : null,
                        Created_Date = dr["Created_Date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["Created_Date"]) : null,
                        Updated_By = dr["Updated_By"] != DBNull.Value ? (int?)Convert.ToInt32(dr["Updated_By"]) : null,
                        Updated_Date = dr["Updated_Date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["Updated_Date"]) : null,
                        Deleted_By = dr["Deleted_By"] != DBNull.Value ? (int?)Convert.ToInt32(dr["Deleted_By"]) : null,
                        Deleted_Date = dr["Deleted_Date"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(dr["Deleted_Date"]) : null
                    };
                    list.Add(tc);
                }
                dr.Close();
                return list;
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
