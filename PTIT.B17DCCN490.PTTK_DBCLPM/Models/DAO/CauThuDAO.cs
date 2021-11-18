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
        #endregion
    }
}
