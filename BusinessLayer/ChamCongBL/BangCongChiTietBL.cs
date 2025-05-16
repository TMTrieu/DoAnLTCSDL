using DataLayer.ChamCongDL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer.ChamCongBL
{
    public class BangCongChiTietBL
    {
        private BangCongChiTietDL _bangCongChiTietDL;

        public BangCongChiTietBL()
        {
            _bangCongChiTietDL = new BangCongChiTietDL();
        }

        public List<BangCongChiTiet> GetBangCongChiTiets(int maKyCong, int idNhanVien)
        {
            try
            {
                return _bangCongChiTietDL.GetBangCongChiTiets(maKyCong, idNhanVien);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public BangCongChiTiet GetCaChiTiet(int maKyCong, int idNhanVien, DateTime ngayChamCong, int loaiCa)
        {
            try
            {
                return _bangCongChiTietDL.GetCaChiTiet(maKyCong, idNhanVien,ngayChamCong,loaiCa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<BangCongChiTiet> GetNgayCongChiTiet(int maKyCong, int idNhanVien, DateTime ngayChamCong)
        {
            try
            {
                return _bangCongChiTietDL.GetNgayCongChiTiet(maKyCong, idNhanVien, ngayChamCong);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool AddBangCongChiTiet(BangCongChiTiet bangCong)
        {
            try
            {
                return _bangCongChiTietDL.AddBangCongChiTiet(bangCong);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdateBangCongChiTiet(BangCongChiTiet bangCong, int id)
        {
            try
            {
                return _bangCongChiTietDL.UpdateBangCongChiTiet(bangCong, id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteBangCongChiTiet(int idBangCong)
        {
            try
            {
                return _bangCongChiTietDL.DeleteBangCongChiTiet(idBangCong);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
