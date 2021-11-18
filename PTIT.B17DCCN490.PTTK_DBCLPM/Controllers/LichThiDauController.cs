using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class LichThiDauController : Controller
    {
        #region Declare
        private readonly IGiaiDauDAO _giaiDauDAO;
        private readonly ILoaiVongDauDAO _loaiVongDauDAO;
        private readonly ITranDauDAO _tranDauDAO;
        #endregion

        #region Constructor
        public LichThiDauController(
            IGiaiDauDAO giaiDauDAO,
            ILoaiVongDauDAO loaiVongDauDAO,
            ITranDauDAO tranDauDAO)
        {
            this._giaiDauDAO = giaiDauDAO;
            this._loaiVongDauDAO = loaiVongDauDAO;
            this._tranDauDAO = tranDauDAO;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Giao diện lịch thi đấu theo vòng đấu và mùa giải
        /// </summary>
        /// <param name="vongDau">Id vòng đấu</param>
        /// <param name="muaGiai">Id mùa giải</param>
        /// <returns>Giao diện lịch thi đấu</returns>
        [HttpGet]
        public IActionResult Index()
        {
            // query string 
            string vongDau = Request.Query["vongDau"];
            string muaGiai = Request.Query["muaGiai"];
            // danh sách giải đấu
            List<GiaiDau> giaiDaus = this._giaiDauDAO.GetAll();
            // setup mùa giải
            if (muaGiai == null)
            {
                string giaiDauId = Request.Cookies["GiaiDauId"];
                muaGiai = giaiDauId == null && giaiDaus.Count() > 0 ? giaiDaus[0].Id.ToString() : giaiDauId;
            }

            // chọn giải đấu
            List<SelectListItem> dropGD =
                giaiDaus.Select((item, index) => new SelectListItem()
                {
                    Text = item.Ten,
                    Value = item.Id.ToString(),
                    Selected = muaGiai == null && index == 0 ||
                               muaGiai != null && item.Id.ToString() == muaGiai ? true : false
                }).ToList();
            // chọn loại vòng đấu
            List<SelectListItem> dropLVD =
                this._loaiVongDauDAO.GetAll().Select((item, index) => new SelectListItem()
                {
                    Text = item.Ten,
                    Value = item.Id.ToString(),
                    Selected = vongDau == null && index == 0 ||
                               vongDau != null && item.Id.ToString() == vongDau ? true : false
                }).ToList();

            // dropdown không có giá trị
            List<TranDau> listTranDaus = new List<TranDau>();
            ViewData["Active"] = "schedule";
            if (dropLVD.Count() == 0 || 
                dropGD.Count() == 0)
            {
                return View(listTranDaus);
            }
            // lấy trận đấu theo vòng đấu giải đấu
            muaGiai = muaGiai == null ? dropGD[0].Value : muaGiai;
            vongDau = vongDau == null ? dropGD[0].Value : vongDau;
            listTranDaus = this._tranDauDAO.GetTranDausByVongDauGiaiDau(Guid.Parse(muaGiai), Guid.Parse(vongDau));

            ViewBag.GiaiDaus = dropGD;
            ViewBag.VongDaus = dropLVD;
            ViewData["CurrentSeason"] = muaGiai;
            ViewData["CurrentGroundStage"] = vongDau;
            return View(listTranDaus);
        }
        #endregion
    }
}
