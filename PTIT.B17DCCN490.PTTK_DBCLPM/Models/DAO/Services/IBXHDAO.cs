using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface IBXHDAO : IBaseDAO<BXH>
    {
        /// <summary>
        /// Lấy danh sách xếp hạng đội bóng theo điểm
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về danh sách đội bóng theo điểm</returns>
        public List<BXH> GetTKBXH(Guid giaiDauId);
    }
}
