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
    public class TonGiaoBL
    {
        private TonGiaoDL tonGiaoDL;
        public TonGiaoBL()
        {
            tonGiaoDL = new TonGiaoDL();
        }
        public List<TonGiao> GetTonGiaos()
        {
            try
            {
                return (tonGiaoDL.GetTonGiaos());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool AddTonGiao(TonGiao tonGiao)
        {

            try
            {
                return tonGiaoDL.AddTonGiao(tonGiao);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdateTonGiao(TonGiao tonGiao)
        {
            try
            {
                return tonGiaoDL.UpdateTonGiao(tonGiao);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteTonGiao(int id)
        {
            try
            {
                return tonGiaoDL.DeleteTonGiao(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
