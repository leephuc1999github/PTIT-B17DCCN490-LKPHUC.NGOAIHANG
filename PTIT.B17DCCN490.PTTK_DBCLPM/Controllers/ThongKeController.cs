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
            // loại thống kê
            if (loai == null)
            {
                loai = "goal";
            }
            // chọn giải đấu
            List<SelectListItem> dropdownGiaiDau =
                this._giaiDauDAO.GetAll().Select((item, index) => new SelectListItem() 
                {
                    Text = item.Ten,
                    Value = item.Id.ToString(),
                    Selected =  muaGiai == null && index == 0 || 
                                muaGiai != null && item.Id == muaGiai ? true : false 
                }).ToList();

            ViewBag.GiaiDaus = dropdownGiaiDau;

            switch (loai)
            {
                case "goal":
                    if(dropdownGiaiDau.Count() > 0)
                    {
                        muaGiai = muaGiai == null ? Guid.Parse(dropdownGiaiDau[0].Value) : muaGiai;
                        List<BXHCauThuBanThang> bxh = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs((Guid)muaGiai);
                        ViewData["TKGoal"] = bxh;
                    }
                    break;
                case "result":
                    if (dropdownGiaiDau.Count() > 0)
                    {
                        muaGiai = muaGiai == null ? Guid.Parse(dropdownGiaiDau[0].Value) : muaGiai;
                        List<BXH> bxh = this._bxhDAO.GetTKBXH((Guid)muaGiai);
                        ViewData["TKResult"] = bxh;
                    }
                    break;
            }
            TempData["TypeTK"] = loai;
            TempData["SeasonTK"] = muaGiai;
            ViewData["Active"] = "summary";
            return View();
        }
        #endregion
    }
}
