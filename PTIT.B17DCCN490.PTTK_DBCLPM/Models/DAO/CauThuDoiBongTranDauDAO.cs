using Dapper;
using Microsoft.Extensions.Configuration;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO
{
    public class CauThuDoiBongTranDauDAO : BaseDAO<CauThu_DoiBong_TranDau>, ICauThuDoiBongTranDauDAO
    {

        #region Methods
        /// <summary>
        /// Danh sách đăng ký cầu thủ trận đấu
        /// </summary>
        /// <param name="doiBongTranDauId">Id đội bóng trận đấu</param>
        /// <returns>Danh sách cầu thủ</returns>
        public List<CauThu_DoiBong_TranDau> GetCauThusByDoiBongTranDau(Guid doiBongTranDauId)
        {
            List<CauThu_DoiBong_TranDau> lstDoiHinhRaSan = new List<CauThu_DoiBong_TranDau>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetCauThusByDoiBongTranDauId";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(
                    nameProc,
                    new { _DoiBongTranDauId = doiBongTranDauId.ToString() },
                    commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                lstDoiHinhRaSan = (from DataRow item in tbl.Rows
                                   select new CauThu_DoiBong_TranDau()
                                   {
                                       Id = Guid.Parse(item["Id"].ToString()),
                                       IsDaChinh = item["IsDaChinh"].ToString() == "1" ? true : false,
                                       CauThu = new CauThu()
                                       {
                                           Id = Guid.Parse(item["CauThuId"].ToString()),
                                           Ten = item["Ten"].ToString(),
                                           SoAo = Convert.ToInt32(item["SoAo"].ToString())
                                       }
                                   }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write("GetCauThusByDoiBongTranDau", ex.Message);
            }
            return lstDoiHinhRaSan;
        }

        /// <summary>
        /// Đăng ký danh sách câu thủ tham gia trận đấu
        /// </summary>
        /// <param name="cauThus">Danh sách cầu thủ trận đấu</param>
        /// <param name="doiBongTranDauId">Id đội bóng trận đấu</param>
        /// <returns>Trả về true nếu thêm thành công | Trả về false nếu thêm thất bại</returns>
        public bool RegisterCauThusByDoiBongTranDau(Guid doiBongTranDauId, List<CauThu_DoiBong_TranDau> cauThus)
        {
            bool isSuccess = true;
            try
            {
                // tham số đầu vào proc 
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_DoiBongTranDauId", doiBongTranDauId.ToString());
                // mở kết nối
                this._mySqlConnection.Open();
                // exe
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    // tên proc clear
                    string nameProcClear = "Proc_DeleteCauThuDoiBongTranDauByDoiBongTranDauId";
                    int exeClear = this._mySqlConnection.Execute
                                                        (nameProcClear, parameters, transaction, commandType: CommandType.StoredProcedure);

                    string nameProcRegister = "Proc_InsertCauThuDoiBongTranDau";
                    // exe đăng ký đội hình ra quân
                    foreach (var item in cauThus)
                    {
                        // tham số đầu vào proc
                        parameters = new DynamicParameters();
                        parameters.Add("_DoiBongTranDauId", doiBongTranDauId.ToString());
                        parameters.Add("_CauThuId", item.CauThu.Id.ToString());
                        parameters.Add("_IsDaChinh", item.IsDaChinh);
                        // exe
                        int exe = this._mySqlConnection.Execute
                                                            (nameProcRegister, parameters, transaction, commandType: CommandType.StoredProcedure);
                        if (exe == 0)
                        {
                            isSuccess = false;
                            break;
                        }
                    }

                    // check trạng thái
                    if (isSuccess)
                    {
                        transaction.Commit();
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("RegisterCauThusByDoiBongTranDau", ex.Message);
            }
            return isSuccess ? true : false;
        }
        #endregion
    }
}
