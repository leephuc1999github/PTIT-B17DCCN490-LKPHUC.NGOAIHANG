using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models
{
    public interface IBanToChucDAO : IBaseDAO<BanToChuc>
    {
        /// <summary>
        /// Kiểm tra đang nhập
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public BanToChuc CheckDangNhap(BanToChuc taiKhoan);
    }
}
