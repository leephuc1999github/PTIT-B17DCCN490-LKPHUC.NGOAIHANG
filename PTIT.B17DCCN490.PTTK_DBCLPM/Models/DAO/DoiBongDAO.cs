using Dapper;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO
{
    public class DoiBongDAO : BaseDAO<DoiBong>, IDoiBongDAO
    {
        /// <summary>
        /// Lấy danh sách đội bóng
        /// </summary>
        /// <returns>Danh sách đội bóng</returns>
        public override List<DoiBong> GetAll()
        {
            List<DoiBong> lstDoiBong = new List<DoiBong>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetDoiBongs";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(nameProc, commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                lstDoiBong = (from DataRow item in tbl.Rows
                              select new DoiBong()
                              {
                                  Id = Guid.Parse(item["Id"].ToString()),
                                  Ten = item["Ten"].ToString(),
                                  SanDau = new SanDau() { Ten = item["TenSanDau"].ToString() }
                              }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write("GetAllDoiBong", ex.Message);
            }
            return lstDoiBong;
        }

        /// <summary>
        /// Thêm mới đội bóng
        /// </summary>
        /// <param name="doiBong">Thông tin đội bóng</param>
        /// <returns>Trả về thành công nếu thêm mới thành công</returns>
        public bool InsertDoiBong(DoiBong doiBong)
        {
            bool isSuccess = true;
            try
            {
                // tên proc
                string nameProc = "Proc_InsertDoiBong";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_Ten", doiBong.Ten);
                parameters.Add("_TenSanDau", doiBong.SanDau.Ten);
                parameters.Add("_SoGhe", doiBong.SanDau.SoGhe);
                // mở kết nối
                this._mySqlConnection.Open();
                // exe
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int rowEffects = this._mySqlConnection.Execute(nameProc, parameters, transaction, commandType: CommandType.StoredProcedure);
                    // check trạng thái
                    if (rowEffects != 2)
                    {
                        transaction.Rollback();
                        isSuccess = false;
                    }
                    else transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.Write("", ex.Message);
            }
            return isSuccess ? true : false;
        }
    }
}
