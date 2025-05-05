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
    public class TrinhDoBL
    {
        private TrinhDoDL trinhDoDL;
        public TrinhDoBL()
        {
            trinhDoDL = new TrinhDoDL();
        }
        public List<TrinhDo> GetTrinhDos()
        {
            try
            {
                return (trinhDoDL.GetTrinhDos());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool AddTrinhDo(TrinhDo trinhDo)
        {

            try
            {
                return trinhDoDL.AddTrinhDo(trinhDo);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdateTrinhDo(TrinhDo trinhDo)
        {
            try
            {
                return trinhDoDL.UpdateTrinhDo(trinhDo);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteTrinhDo(int id)
        {
            try
            {
                return trinhDoDL.DeleteTrinhDo(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
