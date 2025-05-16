using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TransferObject;

namespace BusinessLayer
{
    public class TangCaBL
    {
        private TangCaDL tangcaDL;

        public TangCaBL()
        {
            tangcaDL = new TangCaDL();
        }

        public List<TangCa> GetTangCas()
        {
            try
            {
                return tangcaDL.GetTangCas();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Add(TangCa tc)
        {
            try
            {
                
                tangcaDL.Add(tc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(TangCa tc)
        {
            try
            {
                tangcaDL.Update(tc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Delete(int id, int? deletedBy = null)
        {
            try
            {
                tangcaDL.Delete(id, deletedBy);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
