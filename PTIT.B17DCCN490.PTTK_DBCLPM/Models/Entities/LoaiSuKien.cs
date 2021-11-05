using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class LoaiSuKien
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Tên
        /// </summary>
        public string Ten { get; set; }
        
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }
    }
}
