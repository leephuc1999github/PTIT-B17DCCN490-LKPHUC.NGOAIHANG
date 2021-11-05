using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class BXH : DoiBong
    {
        /// <summary>
        /// Thứ hạng 
        /// </summary>
        public int ThuHang { get; set; }

        /// <summary>
        /// Tổng điểm
        /// </summary>
        public int Diem { get; set; }

        /// <summary>
        /// Số bàn thắng
        /// </summary>
        public int BanThang { get; set; }

        /// <summary>
        /// Số bàn thắng
        /// </summary>
        public int BanThua { get; set; }

        /// <summary>
        /// Hiệu số
        /// </summary>
        public int HieuSo { get; set; }

        /// <summary>
        /// Số trận
        /// </summary>
        public int SoTran { get; set; }
    }
}
