using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface IBXHCauThuBanThangDAO : IBaseDAO<BXHCauThuBanThang>
    {
        /// <summary>
        /// Lấy danh sách bảng xếp hạng cầu thủ theo bàn thắng
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về bảng xếp hạng cầu thủ theo bàn thắng</returns>
        public List<BXHCauThuBanThang> GetTKCauThuBangThangs(Guid giaiDauId);
    }
}
