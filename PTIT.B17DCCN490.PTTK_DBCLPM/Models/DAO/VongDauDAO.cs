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
            VongDau objVongDau = new VongDau();
            try
            {
                // tên proc
                string nameProc = "Proc_GetVongDauByGiaiDauIdAndLoaiVongDauId";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_GiaiDauId", giaiDauId);
                parameters.Add("_LoaiVongDauId", loaiVongDauId);
                // exe
                objVongDau = this._mySqlConnection.Query<VongDau>(nameProc, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Write("GetVongDauByGiaiDauAndLoaiVongDau", ex.Message);
            }
            return objVongDau;
        }
    }
}
