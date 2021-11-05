using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface ICauThuDoiBongTranDauDAO : IBaseDAO<CauThu_DoiBong_TranDau>
    {
        /// <summary>
        /// Danh sách đăng ký cầu thủ trận đấu
        /// </summary>
        /// <param name="doiBongTranDauId">Id đội bóng trận đấu</param>
        /// <returns>Danh sách cầu thủ</returns>
        public List<CauThu_DoiBong_TranDau> GetCauThusByDoiBongTranDau(Guid doiBongTranDauId);

        /// <summary>
        /// Đăng ký danh sách câu thủ tham gia trận đấu
        /// </summary>
        /// <param name="cauThus">Danh sách cầu thủ trận đấu</param>
        /// <returns>Trả về true nếu thêm thành công | Trả về false nếu thêm thất bại</returns>
        public bool RegisterCauThusByDoiBongTranDau(Guid doiBongTranDauId, List<CauThu_DoiBong_TranDau> cauThus);
    }
}
