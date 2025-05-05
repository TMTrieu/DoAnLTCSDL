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
    public class ChucVuBL
    {
        private ChucVuDL chucVuDL;

        public ChucVuBL()
        {
            chucVuDL = new ChucVuDL();
        }

        public List<ChucVu> GetChucVus()
        {
            try
            {
                return chucVuDL.GetChucVus();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public bool AddChucVu(ChucVu chucVu)
        {
            try
            {

                return chucVuDL.AddChucVu(chucVu);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UpdateChucVu(ChucVu chucVu)
        {
            try
            {
                return chucVuDL.UpdateChucVu(chucVu);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteChucVu(int id)
        {
            try
            {
                return chucVuDL.DeleteChucVu(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
