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
    public class HDLaoDongBL
    {
        private HDLaoDongDL hdlaodongDL;

       
        public HDLaoDongBL()
        {
            hdlaodongDL = new HDLaoDongDL();
        }

        public List<HDLaoDong> GetHopDongs()
        {
            try
            {
                return hdlaodongDL.GetHopDongs();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<HDLaoDong> GetHopDongsWithNhanVien()
        {
            try
            {
                return hdlaodongDL.GetHopDongsWithNhanVien();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public HDLaoDong GetHopDongBySoHD(string soHD)
        {
            try
            {
                return hdlaodongDL.GetHopDongBySoHD(soHD); 
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi khi lấy hợp đồng: " + ex.Message, ex);
            }
        }


        public string GetAvailableSoHD()
        {
            try
            {
                return hdlaodongDL.GetAvailableSoHD();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public void Add(HDLaoDong hdld)
        {
            try
            {
                hdld.SoHD = hdlaodongDL.GetAvailableSoHD();
                hdld.IdHopDong = hdlaodongDL.GetAvailableId();
           
                hdld.Created_Date = DateTime.Now;
                hdlaodongDL.Add(hdld);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Update(HDLaoDong hdld)
        {
            try
            {
                hdld.Updated_Date = DateTime.Now;
                hdlaodongDL.Update(hdld);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void Delete(string soHD, int deletedBy)
        {
            try
            {
                hdlaodongDL.Delete(soHD,deletedBy);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
