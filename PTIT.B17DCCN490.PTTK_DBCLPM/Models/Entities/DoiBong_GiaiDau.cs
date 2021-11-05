using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class DoiBong_GiaiDau
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Thông tin đội bóng
        /// </summary>
        public DoiBong DoiBong { get; set; }

        /// <summary>
        /// Thông tin bảng đấu
        /// </summary>
        public BangDau BangDau { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }

    }
}
