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
    public class DanTocBL
    {
        private DanTocDL danTocDL;
        public DanTocBL() 
        {
            danTocDL = new DanTocDL(); 
        }
        public List<DanToc> GetDanTocs()
        {
            try
            {
                return (danTocDL.GetDanTocs());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool AddDanToc(DanToc danToc)
        {
            
            try
            {
                return danTocDL.AddDanToc(danToc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdateDanToc(DanToc danToc)
        {
            try
            {
                return danTocDL.UpdateDanToc(danToc);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteDanToc(int id)
        {
            try
            {
                return danTocDL.DeleteDanToc(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
