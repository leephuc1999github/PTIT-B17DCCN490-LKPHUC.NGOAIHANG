using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface ICauThuDAO : IBaseDAO<CauThu>
    {

        /// <summary>
        /// Lấy danh sách cầu thủ theo đội bóng
        /// </summary>
        /// <param name="doiBongId">Id đội bóng</param>
        /// <returns>Trả về danh sách cầu thủ theo đội bóng</returns>
        public List<CauThu> GetCauThusByDoiBong(Guid doiBongId);
    }
}
