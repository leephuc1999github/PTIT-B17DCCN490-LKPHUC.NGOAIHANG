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
        [HttpGet]
        public IActionResult Index(Guid? vongDau, Guid? muaGiai)
        {
            // chọn giải đấu
            List<SelectListItem> dropdownGiaiDau =
                this._giaiDauDAO.GetAll().Select((item, index) => new SelectListItem()
                {
                    Text = item.Ten,
                    Value = item.Id.ToString(),
                    Selected = muaGiai == null && index == 0 ||
                               muaGiai != null && item.Id == muaGiai ? true : false
                }).ToList();

            List<SelectListItem> dropdownLoaiVongDau =
                this._loaiVongDauDAO.GetAll().Select((item, index) => new SelectListItem()
                {
                    Text = item.Ten,
                    Value = item.Id.ToString(),
                    Selected = vongDau == null && index == 0 ||
                               vongDau != null && item.Id == vongDau ? true : false
                }).ToList();

            //List<TranDau> listTranDaus = new List<TranDau>()
            //{
            //    new TranDau()
            //    {
            //        ThoiGianBD = DateTime.Now,
            //        DoiNha = new DoiBong_TranDau(){ DoiBong = new DoiBong(){ Ten = "Chelsea" } },
            //        DoiKhach = new DoiBong_TranDau() { DoiBong = new DoiBong(){ Ten = "MU" } }
            //    }
            //};
            List<TranDau> listTranDaus = new List<TranDau>();
            ViewData["Active"] = "schedule";
            if (dropdownLoaiVongDau.Count() == 0 || 
                dropdownGiaiDau.Count() == 0)
            {
                return View(listTranDaus);
            }
            muaGiai = muaGiai == null ? Guid.Parse(dropdownGiaiDau[0].Value) : muaGiai;
            vongDau = vongDau == null ? Guid.Parse(dropdownLoaiVongDau[0].Value) : vongDau;
            listTranDaus = this._tranDauDAO.GetTranDausByVongDauGiaiDau((Guid)muaGiai, (Guid)vongDau);

            ViewBag.GiaiDaus = dropdownGiaiDau;
            ViewBag.VongDaus = dropdownLoaiVongDau;
            TempData["CurrentSeason"] = muaGiai;
            TempData["CurrentGroundStage"] = vongDau;
            return View(listTranDaus);
        }
        #endregion
    }
}
