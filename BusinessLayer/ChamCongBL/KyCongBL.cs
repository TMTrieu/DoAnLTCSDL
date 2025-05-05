using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.QuanLyChamCongDL;
using TransferObject;

namespace BusinessLayer
{
    public class KyCongBL
    {
        private KyCongDL kyCongDL;
        public KyCongBL() { kyCongDL = new KyCongDL(); }
        public List<KyCong> GetKyCongs()
        {
            try
            {
                return kyCongDL.GetKyCongs();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool AddKyCong(KyCong kyCong)
        {
            try
            {
                return kyCongDL.AddKyCong(kyCong);
            }
            catch (SqlException ex) { throw ex; }
        }
        public bool UpdateKyCong(KyCong kyCong)
        {
            try
            {
                return kyCongDL.UpdateKyCong(kyCong);
            }
            catch (SqlException ex) { throw ex; }
        }
        public bool DeleteKyCong(int id)
        {
            try
            {
                return kyCongDL.DeleteKyCong(id);
            }
            catch (SqlException ex) { throw ex; }
        }
    }
}
