using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class NhanVienPhuCapBL
    {
        private NhanVienPhuCapDL nvpcDL;

        public NhanVienPhuCapBL()
        {
            nvpcDL = new NhanVienPhuCapDL();
        }

        public List<NhanVienPhuCap> GetNhanVienPhuCaps()
        {
            try
            {
                return nvpcDL.GetNhanVienPhuCaps();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên phụ cấp: " + ex.Message, ex);
            }
        }


        public void Add(NhanVienPhuCap nvpc)
        {
            try
            {
                nvpc.IdNhanVienPhuCap = nvpcDL.GetAvailableId();
                nvpcDL.Add(nvpc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên phụ cấp: " + ex.Message, ex);
            }
        }

        public void Update(NhanVienPhuCap nvpc)
        {
            try
            {
                nvpcDL.Update(nvpc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên phụ cấp: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                nvpcDL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên phụ cấp: " + ex.Message, ex);
            }
        }
    }
}
