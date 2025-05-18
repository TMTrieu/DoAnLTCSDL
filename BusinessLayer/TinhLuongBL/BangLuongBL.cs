using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject.TinhLuong;


namespace BusinessLayer
{
    public class BangLuongBL
    {
        private BangLuongDL bangLuongDL = new BangLuongDL();
        public BangLuong GetItem(int maKyCong, int idNhanVien)
        {
            try
            {
                return bangLuongDL.GetItem(maKyCong, idNhanVien);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BangLuong> GetListByMaKyCong(int maKyCong)
        {
            try
            {
                return bangLuongDL.GetListByMaKyCong(maKyCong);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Add(BangLuong bangLuong)
        {
            try
            {
                return bangLuongDL.Add(bangLuong);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public int Update(BangLuong bangLuong)
        {
            try
            {
                return bangLuongDL.Update(bangLuong);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return bangLuongDL.Delete(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}

