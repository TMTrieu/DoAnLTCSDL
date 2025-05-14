using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class YeuCauThoiViecBL
    {
        private YeuCauThoiViecDL ycTVDL;
        public YeuCauThoiViecBL()
        {
            ycTVDL = new YeuCauThoiViecDL();
        }

        public List<YeuCauThoiViec> GetYeuCau(int idNhanVien)
        {
            try
            {
                return ycTVDL.GetYeuCaus().Where(yc => yc.IdNhanVien == idNhanVien).ToList();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public List<YeuCauThoiViec> GetYeuCaus()
        {
            try
            {
                return ycTVDL.GetYeuCaus();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public bool GuiYeuCau(YeuCauThoiViec yeuCau)
        {
            try
            {
                // Mặc định trạng thái là "ChoDuyet"
                yeuCau.TrangThai = "ChoDuyet";
                yeuCau.NgayYeuCau = DateTime.Now;
                yeuCau.NgayPheDuyet = null;
                yeuCau.GhiChu = null;
                return ycTVDL.AddYeuCau(yeuCau);

               
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool PheDuyetYeuCau(YeuCauThoiViec yc, bool chapNhan)
        {
            try
            {
                yc.TrangThai = chapNhan ? "DaPheDuyet" : "TuChoi";
                yc.NgayPheDuyet = DateTime.Now;

                return ycTVDL.UpdateYeuCau(yc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteYeuCau(int id)
        {
            try
            {
                return ycTVDL.DeleteYeuCau(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int GuiYeuCauVaLayId(YeuCauThoiViec yeuCau)
        {
            try
            {
                // Tạo ID trước
                yeuCau.IdYeuCau = ycTVDL.GetNextAvailableIdYeuCau();
                yeuCau.TrangThai = "ChoDuyet";
                yeuCau.NgayYeuCau = DateTime.Now;
                yeuCau.NgayPheDuyet = null;
                yeuCau.GhiChu = null;

                bool thanhCong = ycTVDL.AddYeuCau(yeuCau);
                return thanhCong ? yeuCau.IdYeuCau : -1;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool CapNhatLoaiLyDo(int idYeuCau, string loaiLyDo)
        {
            try
            {
                var yc = ycTVDL.GetYeuCaus().FirstOrDefault(y => y.IdYeuCau == idYeuCau);
                if (yc == null) return false;

                return ycTVDL.UpdateYeuCau(yc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
