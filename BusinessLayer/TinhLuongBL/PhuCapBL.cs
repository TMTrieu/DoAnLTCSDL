using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class PhuCapBL
    {
        
            private PhuCapDL phucapDL;

            public PhuCapBL()
            {
                phucapDL = new PhuCapDL();
            }

            public List<PhuCap> GetPhuCaps()
            {
                try
                {
                    return phucapDL.GetPhuCaps();
                }
                catch (SqlException ex)
                {

                    throw ex;
                }
            }
        public PhuCap GetItemPhuCap(int id)
        {
            try
            {
                return phucapDL.GetItemPhuCap(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public void Add(PhuCap pc)
            {
                try
                {
                    pc.IdPhuCap = phucapDL.GetAvailableId();
                    phucapDL.Add(pc);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }

        public void Update(PhuCap pc)
        {
            try
            {
                phucapDL.Update(pc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phụ cấp: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                phucapDL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phụ cấp: " + ex.Message, ex);
            }
        }
    
    }
}
