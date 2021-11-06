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
    public class BXHDAO : BaseDAO<BXH>, IBXHDAO
    {
        #region Methods
        /// <summary>
        /// Lấy danh sách xếp hạng đội bóng theo điểm
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về danh sách đội bóng theo điểm</returns>
        public List<BXH> GetTKBXH(Guid giaiDauId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_GiaiDauId", giaiDauId);
            return this._mySqlConnection.Query<BXH>("Proc_GetBXH", parameters, commandType: CommandType.StoredProcedure).ToList();
        }
        #endregion
    }
}
