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
    public class KyCongChiTietBL
    {
        private KyCongChiTietDL kyCongChiTietDL;
        public KyCongChiTietBL()
        {
            kyCongChiTietDL = new KyCongChiTietDL();
        }
        public List<KyCongChiTiet> GetKyCongChiTiets(int maKyCong)
        {
            try
            {
                return kyCongChiTietDL.GetKyCongChiTiets(maKyCong);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void PhatSinhKyCong(int thang, int nam)
        {
            try
            {
                kyCongChiTietDL.PhatSinhKyCong(thang, nam);
            }catch (Exception ex) {throw ex;}
        }
        public bool CapNhatBangCong(string tenCot,string chamCong, int maKyCong, int maNhanVien)
        {
            try
            {
                return kyCongChiTietDL.CapNhatBangCong(tenCot, chamCong, maKyCong, maNhanVien);
            }
            catch(SqlException ex) { throw ex; }
        }

    }
}
