using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface ITranDauDAO : IBaseDAO<TranDau>
    {
        /// <summary>
        /// Lấy danh sách trận đấu theo cầu thủ ghi bàn
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <param name="cauThuId">Id cầu thủ</param>
        /// <returns>Trả về danh sách trận đấu cầu thủ ghi bàn</returns>
        public List<TranDau> GetTranDausByCauThuGhiBan(Guid giaiDauId, Guid cauThuId);

        /// <summary>
        /// Lấy danh sách trận đấu theo loại vòng đầu
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <param name="loaiVongDauId">Id loại vòng đấu</param>
        /// <returns>Trả về danh sách trận đấu theo loại vòng đấu</returns>
        public List<TranDau> GetTranDausByVongDauGiaiDau(Guid giaiDauId, Guid loaiVongDauId);

        /// <summary>
        /// Thêm mới trận đấu
        /// </summary>
        /// <param name="tranDau">Thông tin trận đấu</param>
        /// <returns>Trả về thông tin trận đấu</returns>
        public TranDau InsertTranDau(TranDau tranDau, Guid vongDauId);
    }
}
