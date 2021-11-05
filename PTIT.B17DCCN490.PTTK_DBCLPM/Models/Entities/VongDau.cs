using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class VongDau
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Thông tin vòng đấu
        /// </summary>
        public LoaiVongDau LoaiVongDau { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get; set; }

        /// <summary>
        /// Số lượng trận
        /// </summary>
        public int SLTran { get; set; }

        /// <summary>
        /// Danh sách trận đấu
        /// </summary>
        public List<TranDau> TranDaus { get; set; }
    }
}
