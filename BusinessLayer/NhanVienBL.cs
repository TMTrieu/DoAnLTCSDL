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
    public class NhanVienBL 
    {
        private NhanVienDL nhanVienDL;

        public NhanVienBL()
        {
            nhanVienDL = new NhanVienDL();
        }
        public List<NhanVien> getNhanViens()
        {
            try
            {
                return nhanVienDL.GetNhanViens();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public void Add(NhanVien nv)
        {
            try
            {                
                nhanVienDL.Add(nv);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void Update(NhanVien nv)
        {
            try
            {
                nhanVienDL.Update(nv);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                nhanVienDL.Delete(id);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
      

    }
}
