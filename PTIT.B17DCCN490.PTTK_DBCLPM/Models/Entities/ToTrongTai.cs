using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class ToTrongTai
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Mã tổ
        /// </summary>
        public string Ma { get; set; }
        
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Trọng tài chính
        /// </summary>
        public TrongTai_ToTrongTai TrongTaiChinh { get; set; }
        
        /// <summary>
        /// Trọng tài biên 1
        /// </summary>
        public TrongTai_ToTrongTai TrongTaiBien1 { get; set; }
        
        /// <summary>
        /// Trọng tại biên 2
        /// </summary>
        public TrongTai_ToTrongTai TrongTaiBien2 { get; set; }
        
        /// <summary>
        /// Trọng tài bàn
        /// </summary>
        public TrongTai_ToTrongTai TrongTaiBan { get; set; }
    }
}
