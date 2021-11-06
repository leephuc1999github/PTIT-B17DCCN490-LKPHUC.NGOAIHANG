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
        public IActionResult Index()
        {
            ViewData["Active"] = "register";
            return RedirectToAction("Index", "LichThiDau");
        }

        [HttpGet("{id}")]
        public IActionResult Index(Guid id, Guid? doiBongId)
        {
            List<CauThu> cauThus = new List<CauThu>();
            if (doiBongId != null)
            {
                cauThus = this._cauThuDAO.GetCauThusByDoiBong((Guid)doiBongId);
            }
            List<CauThu_DoiBong_TranDau> cauThuDaDKs = this._cauThuDoiBongTranDauDAO.GetCauThusByDoiBongTranDau(id);
            ViewData["CauThu"] = cauThuDaDKs;
            ViewData["Active"] = "register";
            ViewBag.DoiBongTranDauId = id.ToString();
            return View(cauThus);
        }

        [HttpPost("{id}")]
        public IActionResult DangKy(Guid id, [FromBody] List<CauThu_DoiBong_TranDau> data)
        {
            bool exe = this._cauThuDoiBongTranDauDAO.RegisterCauThusByDoiBongTranDau(id, data);
            return Ok(exe);
        }
        #endregion
    }
}
