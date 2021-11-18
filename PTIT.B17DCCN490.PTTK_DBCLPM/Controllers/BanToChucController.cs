using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ENUM;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    public class BanToChucController : BaseController<BanToChuc>
    {
        #region Declare
        private readonly IBanToChucDAO _banToChucDAO;
        private ToastMessage message;
        #endregion

        #region Constructor
        public BanToChucController(IBanToChucDAO banToChucDAO)
        {
            this._banToChucDAO = banToChucDAO;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Giao diện đăng nhập
        /// </summary>
        /// <returns>Trả về giao diện đăng nhập</returns>
        [HttpGet]
        [Route("DangNhap")]
        public IActionResult DangNhap()
        {
            return View();
        }

        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <returns>Trả về giao diện trang chủ</returns>
        [HttpPost]
        public IActionResult KiemTraDangNhap(BanToChuc btc)
        {
            // check from db
            BanToChuc objBTC = this._banToChucDAO.CheckDangNhap(btc);
            // lỗi server
            if (objBTC == null)
            {
                message = new ToastMessage()
                {
                    Type = TypeToast.error,
                    Content = "Tên đăng nhập hoặc mật khẩu không chính xác",
                    Name = "Login"
                };
                TempData["UserMessage"] = JsonConvert.SerializeObject(message);
                return RedirectToAction("DangNhap");
            }
            else
            {
                // sinh cookie
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, btc.Id.ToString()),
                    new Claim(ClaimTypes.Name, btc.TenDangNhap),
                    new Claim(ClaimTypes.Role, "admin"),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                // chuyển giao diện trang chủ
                return RedirectToAction("", "TrangChu");
            }
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <returns>Trả về giao diện đăng nhập</returns>
        [HttpGet]
        [Route("DangXuat")]
        public IActionResult DangXuat()
        {
            // xóa cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // chuyển giao diện đăng nhập
            return RedirectToAction("DangNhap");
        }
        #endregion
    }
}

