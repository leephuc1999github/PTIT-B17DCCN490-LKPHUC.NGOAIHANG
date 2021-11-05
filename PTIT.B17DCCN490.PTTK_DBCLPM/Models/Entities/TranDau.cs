using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class TranDau
    {
        /// <summary>
        /// Id
        /// </summary>        
        public Guid Id { get; set; }

        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        public DateTime ThoiGianBD { get; set; }

        /// <summary>
        /// Thời gian chính thức
        /// </summary>
        public int TGChinhThuc { get; set; }
        
        /// <summary>
        /// Đã kết thúc
        /// </summary>
        public bool DaKetThuc { get; set; }
        
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string GhiChu { get; set; }
        
        /// <summary>
        /// Đang diễn ra
        /// </summary>
        public bool DangDienRa { get; set; }
        
        /// <summary>
        /// Tổng số vé
        /// </summary>
        public int TongSoVe { get; set; }
        
        /// <summary>
        /// Số bù giờ
        /// </summary>
        public int BuGio { get; set; }

        /// <summary>
        /// Thông tin sân đấu
        /// </summary>
        public SanDau SanDau { get; set; }

        /// <summary>
        /// Đội nhà
        /// </summary>
        public DoiBong_TranDau DoiNha { get; set; }

        /// <summary>
        /// Đội khách
        /// </summary>
        public DoiBong_TranDau DoiKhach { get; set; }
        
        /// <summary>
        /// Thông tin tổ trọng tài
        /// </summary>
        public ToTrongTai ToTrongTai { get; set; }
    }
}
