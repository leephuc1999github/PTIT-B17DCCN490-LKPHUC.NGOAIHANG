using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class GiaiDau
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên giải đấu
        /// </summary>
        public string Ten { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string MoTa { get; set; }

        /// <summary>
        /// Mùa giải
        /// </summary>
        public string MuaGiai { get; set; }

        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        public DateTime ThoiGianBD { get; set; }

        /// <summary>
        /// Thời gian dự kiến kết thúc
        /// </summary>
        public DateTime ThoiGianDuKienKT { get; set; }

        /// <summary>
        /// Danh sách vòng đấu
        /// </summary>
        public List<VongDau> VongDaus { get; set; }

        /// <summary>
        /// Danh sách đội bóng
        /// </summary>
        public List<DoiBong_GiaiDau> DoiBongs { get; set; }
    }
}
