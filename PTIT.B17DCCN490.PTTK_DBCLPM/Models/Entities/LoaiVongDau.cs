using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class LoaiVongDau
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên vòng đấu
        /// </summary>
        public string Ten { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get; set; }

    }
}
