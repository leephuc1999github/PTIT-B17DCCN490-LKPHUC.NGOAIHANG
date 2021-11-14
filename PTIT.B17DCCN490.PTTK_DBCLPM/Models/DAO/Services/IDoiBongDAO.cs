using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services
{
    public interface IDoiBongDAO : IBaseDAO<DoiBong>
    {
        /// <summary>
        /// Thêm mới đội bóng
        /// </summary>
        /// <param name="doiBong">Thông tin đội bóng</param>
        /// <returns>Trả về thành công nếu thêm mới thành công</returns>
        public bool InsertDoiBong(DoiBong doiBong);
    }
}
