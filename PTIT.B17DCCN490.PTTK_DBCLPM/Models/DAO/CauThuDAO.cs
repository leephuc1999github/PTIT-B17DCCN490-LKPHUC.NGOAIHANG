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
    public class CauThuDAO : BaseDAO<CauThu>, ICauThuDAO
    {
        #region Methods

        /// <summary>
        /// Lấy danh sách cầu thủ theo đội bóng
        /// </summary>
        /// <param name="doiBongId">Id đội bóng</param>
        /// <returns>Trả về danh sách cầu thủ theo đội bóng</returns>
        public List<CauThu> GetCauThusByDoiBong(Guid doiBongId)
        {
            List<CauThu> lstCauThu = new List<CauThu>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetCauThusByDoiBongId";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_DoiBongId", doiBongId.ToString());
                // exe
                lstCauThu = this._mySqlConnection.Query<CauThu>
                                                (nameProc, parameters, commandType: CommandType.StoredProcedure)
                                                .ToList();
            }
            catch (Exception ex)
            {
                Logger.Write("GetCauThusByDoiBong", ex.Message);
            }
            return lstCauThu;
        }


        /// <summary>
        /// Thêm mới cầu thủ
        /// </summary>
        /// <param name="doiBongId">Id đội bóng</param>
        /// <param name="cauThu">Thông tin cầu thủ</param>
        /// <returns>Trả về true nếu thực hiện thành công</returns>
        public bool InsertCauThu(Guid doiBongId, CauThu cauThu)
        {
            bool isSuccess = true;
            try
            {
                // tên proc
                string nameProc = "Proc_InsertCauThu";

                // tham số truyền vào store
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_Ten", cauThu.Ten);
                parameters.Add("_SoAo", cauThu.SoAo);
                parameters.Add("_ChieuCao", cauThu.ChieuCao);
                parameters.Add("_CanNang", cauThu.CanNang);
                parameters.Add("_ChanThuan", cauThu.ChanThuan);
                parameters.Add("_DoiBongId", doiBongId);

                // mở kết nối
                this._mySqlConnection.Open();
                // exe
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int exe = this._mySqlConnection.Execute(nameProc, parameters, transaction, commandType: CommandType.StoredProcedure);
                    if (exe == 1)
                    {
                        transaction.Commit();
                    }
                    else isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("InsertCauThu", ex.Message);
            }
            return isSuccess ? true : false;
        }
        #endregion
    }
}
