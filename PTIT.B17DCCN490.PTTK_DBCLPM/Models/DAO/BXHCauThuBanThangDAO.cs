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
    public class BXHCauThuBanThangDAO : BaseDAO<BXHCauThuBanThang>, IBXHCauThuBanThangDAO
    {
        #region Methods
        /// <summary>
        /// Lấy danh sách thống kê cầu thủ ghi bàn
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về danh sách cầu thủ ghi bàn</returns>
        public List<BXHCauThuBanThang> GetTKCauThuBangThangs(Guid giaiDauId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_GiaiDauId", giaiDauId.ToString());
            List<BXHCauThuBanThang> bxh = this._mySqlConnection.Query<BXHCauThuBanThang>("Proc_GetTKCauThuBanThangs", parameters, commandType: CommandType.StoredProcedure).ToList();
            return bxh;

        }
        #endregion
    }
}
