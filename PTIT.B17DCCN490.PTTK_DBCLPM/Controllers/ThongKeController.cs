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

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Authorize(Roles = "admin")]
    public class ThongKeController : Controller
    {
        #region Declare
        private IGiaiDauDAO _giaiDauDAO;
        private IBXHCauThuBanThangDAO _bxhCauThuBanThangDAO;
        private IBXHDAO _bxhDAO;
        #endregion

        #region Constructor
        public ThongKeController(
            IGiaiDauDAO giaiDauDAO,
            IBXHCauThuBanThangDAO bxhCauThuBanThangDAO,
            IBXHDAO bxhDAO)
        {
            this._giaiDauDAO = giaiDauDAO;
            this._bxhCauThuBanThangDAO = bxhCauThuBanThangDAO;
            this._bxhDAO = bxhDAO;
        }
        #endregion


        #region Methods
        public IActionResult Index(string loai, Guid? muaGiai)
        {
            // get ds giải đấu
            List<GiaiDau> giaiDaus = this._giaiDauDAO.GetAll();
            List<SelectListItem> dropdownGiaiDau = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn giải đấu", Value = null, Selected = true }
            };
            if (giaiDaus.Count() > 0)
            {
                // TH: giaiDau == null => reset giải đấu hiện tại
                if (muaGiai == null)
                {
                    string giaiDauId = Request.Cookies["GiaiDauId"];
                    muaGiai = giaiDauId == null ? giaiDaus[0].Id : new Guid(giaiDauId);
                }
                // options selectbox giải đấu
                dropdownGiaiDau =
                   giaiDaus.Select((item, index) => new SelectListItem()
                   {
                       Text = item.Ten,
                       Value = item.Id.ToString(),
                       Selected = muaGiai == null && index == 0 ||
                                   muaGiai != null && item.Id == muaGiai ? true : false
                   }).ToList();

                // router loại thống kê
                switch (loai)
                {
                    case "goal":
                        List<BXHCauThuBanThang> bxhBT = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs((Guid)muaGiai);
                        ViewData["TKGoal"] = bxhBT;
                        break;
                    case "card":
                        break;
                    case "stadium":
                        break;
                    default:
                        loai = "result";
                        List<BXH> bxh = this._bxhDAO.GetTKBXH((Guid)muaGiai);
                        ViewData["TKResult"] = bxh;
                        break;
                }

            }
            ViewBag.GiaiDaus = dropdownGiaiDau;
            ViewData["TypeTK"] = loai == null ? "result" : loai;
            TempData["CurrentSeason"] = muaGiai;
            ViewData["Active"] = "summary";
            return View("Index");
        }
        #endregion
    }
}
