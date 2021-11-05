using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities.BaseEntity;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class BanToChuc
    {
        /// <summary>
        /// Id ban tổ chức
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên thành viên
        /// </summary>
        public string Ten { get; set; }

        /// <summary>
        /// Tên đăng nhập
        /// </summary>
        public string TenDangNhap { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string MatKhau { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string SDT { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
