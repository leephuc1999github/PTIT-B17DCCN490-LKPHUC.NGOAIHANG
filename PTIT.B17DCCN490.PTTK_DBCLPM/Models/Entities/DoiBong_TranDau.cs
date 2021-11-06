using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class DoiBong_TranDau
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Là đội nhà
        /// </summary>
        public bool IsDoiNha { get; set; }
        
        /// <summary>
        /// Đã thanh toán
        /// </summary>
        public bool DaThanhToan { get; set; }
        
        /// <summary>
        /// Số bàn thắng
        /// </summary>
        public int SoBanThang { get; set; }

        /// <summary>
        /// Điểm sau trận
        /// </summary>
        public int Diem { get; set; }

        /// <summary>
        /// Thông tin đội bóng
        /// </summary>
        public DoiBong_GiaiDau DoiBong { get; set; }

        /// <summary>
        /// Danh sách cầu thủ trận đấu
        /// </summary>
        public List<CauThu_DoiBong_TranDau> CauThus { get; set; }
    }
}
