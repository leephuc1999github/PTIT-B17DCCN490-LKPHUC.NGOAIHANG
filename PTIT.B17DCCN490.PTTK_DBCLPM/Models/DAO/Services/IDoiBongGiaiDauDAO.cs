using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface IDoiBongGiaiDauDAO : IBaseDAO<DoiBong_GiaiDau>
    {
        /// <summary>
        /// Lấy danh sách đội bóng tham gia giải đấu
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về danh sách đội bóng giải đấu</returns>
        public List<DoiBong_GiaiDau> GetDoiBongsByGiaiDau(Guid giaiDauId);

        /// <summary>
        /// Thêm mới đội bóng giải đấu
        /// </summary>
        /// <param name="doiBongGiaiDau">Thông tin đội bóng giải đấu</param>
        /// <returns>Trả về true nếu thực hiện thành công</returns>
        public bool InsertDoiBongGiaiDau(Guid id, DoiBong_GiaiDau doiBongGiaiDau);
    }
}
