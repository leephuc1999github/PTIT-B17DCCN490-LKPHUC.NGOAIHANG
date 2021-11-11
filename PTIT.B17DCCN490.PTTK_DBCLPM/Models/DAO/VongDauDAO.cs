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
    public class VongDauDAO : BaseDAO<VongDau>, IVongDauDAO
    {
        /// <summary>
        /// Lấy vòng đấu theo loại vòng đấu và giải đấu
        /// </summary>
        /// <param name="loaiVongDauId">Id loại vòng đấu</param>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về vòng đấu</returns>
        public VongDau GetVongDauByGiaiDauAndLoaiVongDau(Guid loaiVongDauId, Guid giaiDauId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_GiaiDauId", giaiDauId);
            parameters.Add("_LoaiVongDauId", loaiVongDauId);
            return this._mySqlConnection.Query<VongDau>("Proc_GetVongDauByGiaiDauIdAndLoaiVongDauId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
