using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class TrongTai_ToTrongTai
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Thông tin trọng tài
        /// </summary>
        public TrongTai TrongTai { get; set; }
        
        /// <summary>
        /// Tiền công
        /// </summary>
        public int TienCong { get; set; }
        
        /// <summary>
        /// Đã thanh toán
        /// </summary>
        public bool DaThanhToan { get; set; }
        
        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get; set; }

    }
}
