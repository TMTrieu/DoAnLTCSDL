using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class BoPhanBL
    {
        private BoPhanDL boPhanDL;

        public BoPhanBL()
        {
            boPhanDL = new BoPhanDL();
        }

        public List<BoPhan> GetBoPhans()
        {
            try
            {
                return boPhanDL.GetBoPhans();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public bool AddBoPhan(BoPhan boPhan)
        {
            try
            {
                
                return boPhanDL.AddBoPhan(boPhan);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdateBoPhan(BoPhan boPhan)
        {
            try
            {
                return boPhanDL.UpdateBoPhan(boPhan);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteBoPhan(int id)
        {
            try
            {
                return boPhanDL.DeleteBoPhan(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
