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
    public class LoaiCongBL
    {
        private LoaiCongDL loaiCongDL;
        public LoaiCongBL() { loaiCongDL = new LoaiCongDL(); }
        public List<LoaiCong> GetLoaiCongs()
        {
            try
            {
                return loaiCongDL.GetLoaiCongs();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool AddLoaiCong(LoaiCong loaiCong)
        {
            try
            {
                return loaiCongDL.AddLoaiCong(loaiCong);
            }
            catch (SqlException ex) { throw ex; }
        }
        public bool UpdateLoaiCong(LoaiCong loaiCong)
        {
            try
            {
                return loaiCongDL.UpdateLoaiCong(loaiCong);
            }
            catch (SqlException ex) { throw ex; }
        }
        public bool DeleteLoaiCong(int id)
        {
            try
            {
                return loaiCongDL.DeleteLoaiCong(id);
            }
            catch (SqlException ex) { throw ex; }
        }
    }
}
