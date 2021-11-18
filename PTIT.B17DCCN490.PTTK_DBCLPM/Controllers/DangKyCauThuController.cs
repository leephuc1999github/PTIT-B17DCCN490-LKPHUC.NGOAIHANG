using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("DangKyCauThu")]
    public class DangKyCauThuController : Controller
    {
        #region Declare
        private readonly ICauThuDAO _cauThuDAO;
        private readonly ICauThuDoiBongTranDauDAO _cauThuDoiBongTranDauDAO;
        #endregion

        #region Constructor
        public DangKyCauThuController(
            ICauThuDAO cauThuDAO,
            ICauThuDoiBongTranDauDAO cauThuDoiBongTranDauDAO
            )
        {
            this._cauThuDAO = cauThuDAO;
            this._cauThuDoiBongTranDauDAO = cauThuDoiBongTranDauDAO;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Giao diện đăng ký cầu thủ
        /// </summary>
        /// <returns>trả về giao diện lịch thi đấu</returns>
        public IActionResult Index()
        {
            // chuyển giao diện lịch thi đấu
            return RedirectToAction("Index", "LichThiDau");
        }

        /// <summary>
        /// Giao diện đăng ký cầu thủ
        /// </summary>
        /// <param name="id">Id đội bóng trận đấu</param>
        /// <param name="doiBongId">Id đội bóng</param>
        /// <returns>Giao diện đăng ký cầu thủ của đội bóng</returns>
        [HttpGet("{id}")]
        public IActionResult Index(Guid id)
        {
            // query string đội bóng
            string db = Request.Query["doiBongId"]; 
            // danh sách cầu thủ đội bóng
            List<CauThu> lstCauThu = new List<CauThu>();
            if (db != null)
            {
                lstCauThu = this._cauThuDAO.GetCauThusByDoiBong(Guid.Parse(db));
            }
            // danh sách cầu thủ đã được đăng ký trận đấu
            List<CauThu_DoiBong_TranDau> lstDaDangKy = this._cauThuDoiBongTranDauDAO.GetCauThusByDoiBongTranDau(id);
            ViewData["CauThu"] = lstDaDangKy;
            ViewData["Active"] = "register";
            ViewBag.DoiBongTranDauId = id.ToString();
            return View(lstCauThu);
        }

        /// <summary>
        /// Đăng ký danh sách cầu thủ tham gia thi đấu
        /// </summary>
        /// <param name="id">Id đội bóng trận đấu</param>
        /// <param name="data">Danh sách cầu thủ được chọn</param>
        /// <returns>Trả về trạng thái đăng ký</returns>
        [HttpPost("{id}")]
        public IActionResult DangKy(Guid id, [FromBody] List<CauThu_DoiBong_TranDau> data)
        {
            // exe
            bool exe = this._cauThuDoiBongTranDauDAO.RegisterCauThusByDoiBongTranDau(id, data);
            return Ok(exe);
        }
        #endregion
    }
}
