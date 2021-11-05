using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class CauThu_DoiBong_TranDau
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Là cầu thủ đá chính
        /// </summary>
        public bool IsDaChinh { get; set; }

        /// <summary>
        /// Thông tin cầu thủ
        /// </summary>
        public CauThu CauThu { get; set; }
    }
}
