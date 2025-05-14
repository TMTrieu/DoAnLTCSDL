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
    public class LoaiCaBL
    {
        private LoaiCaDL loaiCaDL;
        public LoaiCaBL() { loaiCaDL = new LoaiCaDL(); }
        public List<LoaiCa> GetLoaiCas()
        {
            try {
                return loaiCaDL.GetLoaiCas();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public LoaiCa GetItem(int id)
        {
            return loaiCaDL.GetItem(id); 
        }


        public bool AddLoaiCa(LoaiCa loaiCa)
        {
            try { 
            
                return loaiCaDL.AddLoaiCa(loaiCa);
                }
            
            catch (SqlException ex) {throw ex;}
        }
        public bool UpdateLoaiCa(LoaiCa loaiCa)
        {
            try
            {
                return loaiCaDL.UpdateLoaiCa(loaiCa);
            }
            catch (SqlException ex) { throw ex; }
        }
        public bool DeleteLoaiCa(int id)
        {
            try
            {
                return loaiCaDL.DeleteLoaiCa(id);
            }
            catch (SqlException ex) { throw ex; }
        }
    }
}
