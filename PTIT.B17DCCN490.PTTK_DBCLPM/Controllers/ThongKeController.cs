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
        private List<GiaiDau> giaiDaus;
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
            giaiDaus = this._giaiDauDAO.GetAll();
        }
        #endregion


        #region Methods
        public IActionResult Index()
        {
            // Tham số query string từ url
            string muaGiai = HttpContext.Request.Query["muaGiai"];
            string loai = HttpContext.Request.Query["loai"];

            Guid giaiDau;
            // Nếu không có query string mùa giải
            if(muaGiai == null)
            {
                // Nếu cookie có tồn tại giải đấu id => gán giải đấu = giá trị từ cookie
                // Nếu cookie không tồn tại giải đấu id => gán = giá trị cầu của danh sách giải đấu
                if(!Guid.TryParse(Request.Cookies["GiaiDauId"], out giaiDau))
                {
                    giaiDau = giaiDaus.Count() > 0 ? giaiDaus[0].Id : new Guid();
                }
            }
            else
            {
                if (!Guid.TryParse(muaGiai, out giaiDau))
                {
                    return RedirectToAction("Index", "Loi");
                }
            }

            // Nếu không có query string loại thống kê
            if(loai == null)
            {
                // Gán loại = bảng xếp hạng đội bóng
                loai = "bxh";
            }else
            {
                // Nếu không thuộc các loại thống kê => trả về gd lỗi
                if (loai != "bxh" && loai != "banthang" && loai != "the" && loai != "san") return RedirectToAction("Index", "Loi");
            }
            

            // get ds giải đấu
            List<SelectListItem> dropGD = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn giải đấu", Value = null, Selected = true }
            };

            
            if (giaiDaus.Count() > 0)
            {
                // options selectbox giải đấu
                dropGD =
                   giaiDaus.Select((item, index) => new SelectListItem()
                   {
                       Text = item.Ten,
                       Value = item.Id.ToString(),
                       Selected = item.Id == giaiDau ? true : false
                   }).ToList();

                // router loại thống kê
                switch (loai)
                {
                    case "banthang":
                        List<BXHCauThuBanThang> bxhBT = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(giaiDau);
                        ViewData["TKGoal"] = bxhBT;
                        break;
                    case "the":
                        break;
                    case "san":
                        break;
                    default:
                        List<BXH> bxh = this._bxhDAO.GetTKBXH(giaiDau);
                        ViewData["TKResult"] = bxh;
                        break;
                }

            }
            ViewBag.GiaiDaus = dropGD;
            ViewData["TypeTK"] = loai;
            ViewData["CurrentSeason"] = giaiDau.ToString();
            ViewData["Active"] = "summary";
            return View("Index");
        }
        #endregion
    }
}
