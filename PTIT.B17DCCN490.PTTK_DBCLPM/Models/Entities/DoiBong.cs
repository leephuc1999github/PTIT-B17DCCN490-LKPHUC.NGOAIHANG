using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class DoiBong
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
        /// Mã
        /// </summary>
        public string Ma { get; set; }
        
        /// <summary>
        /// Áo đấu sân nhà
        /// </summary>
        public string AoDauSN { get; set; }
        
        /// <summary>
        /// Áo đấu sân khách
        /// </summary>
        public string AoDauSK { get; set; }
        
        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get; set; }

        /// <summary>
        /// Thông tin sân đấu
        /// </summary>
        public SanDau SanDau { get; set; }

        /// <summary>
        /// Danh sách cầu thủ
        /// </summary>
        public List<CauThu> CauThus { get; set; }
    }
}
