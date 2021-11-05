using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class SuKien
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Thông tin cầu thủ
        /// </summary>
        public CauThu_DoiBong_TranDau CauThu { get; set; }

        /// <summary>
        /// Loại sự kiện
        /// </summary>
        public LoaiSuKien LoaiSuKien { get; set; }

        /// <summary>
        /// Thời điểm diễn ra
        /// </summary>
        public int ThoiDiem { get; set; }
        
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }
    }
}
