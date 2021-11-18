using Microsoft.AspNetCore.Mvc;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    public class DoiBongController : BaseController<DoiBong>
    {
        #region Declare
        private readonly IDoiBongDAO _doiBongDAO;
        #endregion

        #region Constructor
        public DoiBongController(IDoiBongDAO doiBongDAO)
        {
            this._doiBongDAO = doiBongDAO;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Giao diện danh sách đội bóng
        /// </summary>
        /// <returns>Giao diện danh sách đội bóng trong csdl</returns>
        public override IActionResult Index()
        {
            // exe
            List<DoiBong> lstDoiBong = this._doiBongDAO.GetAll();
            // active menu thiết lập
            ViewData["Active"] = "setting";
            return View("Index", lstDoiBong);
        }

        /// <summary>
        /// Thêm mới đội bóng 
        /// </summary>
        /// <param name="doiBong">Thông tin đội bóng</param>
        /// <returns>Trả về trạng thái thực thi</returns>
        [HttpPost]
        public IActionResult InsertDoiBong([FromBody] DoiBong doiBong)
        {
            bool exe = this._doiBongDAO.InsertDoiBong(doiBong);
            return Ok(exe);
        }
        #endregion
    }
}
