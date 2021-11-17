using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities.BaseEntity;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class BanToChuc : TTNguoi
    {
        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string TenDangNhap { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string MatKhau { get; set; }
    }
}
