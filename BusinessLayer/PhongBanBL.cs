using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class PhongBanBL
    {
        private PhongBanDL phongBanDL;

        public PhongBanBL()
        {
            phongBanDL = new PhongBanDL();
        }

        public List<PhongBan> GetPhongBans()
        {
            try
            {
                return phongBanDL.GetPhongBans();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool AddPhongBan(PhongBan phongBan)
        {
            try
            {
                return phongBanDL.AddPhongBan(phongBan);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdatePhongBan(PhongBan phongBan)
        {
            try
            {
                return phongBanDL.UpdatePhongBan(phongBan);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeletePhongBan(int id)
        {
            try
            {
                return phongBanDL.DeletePhongBan(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
