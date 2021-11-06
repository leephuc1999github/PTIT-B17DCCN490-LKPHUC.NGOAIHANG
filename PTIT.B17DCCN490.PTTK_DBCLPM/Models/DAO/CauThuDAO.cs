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
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_DoiBongId", doiBongId.ToString());
            return this._mySqlConnection.Query<CauThu>("Proc_GetCauThusByDoiBongId", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion
    }
}
