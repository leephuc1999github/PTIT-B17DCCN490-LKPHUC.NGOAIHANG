using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface ISuKienDAO : IBaseDAO<SuKien>
    {
        /// <summary>
        /// Lấy danh sách sự kiện theo trận đấu
        /// </summary>
        /// <param name="tranDauId">Id trận đấu</param>
        /// <returns>Trả về danh sách sự kiện</returns>
        public List<SuKien> GetSuKiensByTranDau(Guid tranDauId);

        /// <summary>
        /// Thêm mới sự kiện
        /// </summary>
        /// <param name="suKien">Thông tin sự kiện</param>
        /// <returns>Trả về true nếu thực hiện thành công | Trả về false nếu thức hiện thất bại</returns>
        public bool InsertSuKien(SuKien suKien);
    }
}
