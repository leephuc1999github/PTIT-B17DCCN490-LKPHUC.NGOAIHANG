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
            List<BXHCauThuBanThang> bxh = new List<BXHCauThuBanThang>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetTKCauThuBanThangs";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_GiaiDauId", giaiDauId.ToString());
                // exe
                bxh = this._mySqlConnection.Query<BXHCauThuBanThang>
                                            (nameProc, parameters, commandType: CommandType.StoredProcedure)
                                            .ToList();
            }
            catch (Exception ex)
            {
                Logger.Write("GetTKCauThuBangThangs", ex.Message);
            }
            return bxh;

        }
        #endregion
    }
}
