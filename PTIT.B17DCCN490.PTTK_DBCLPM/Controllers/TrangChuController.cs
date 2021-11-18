using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Authorize(Roles = "admin")]
    public class TrangChuController : Controller
    {
        #region Methods
        /// <summary>
        /// Giao diện trang chủ
        /// </summary>
        /// <returns>Trả về giao diện trang chủ</returns>
        public IActionResult Index()
        {
            foreach (var item in User.Claims)
            {
                string type = item.Type;
                string value = item.Value;
            }
            // active menu trang chủ
            ViewData["Active"] = "home";
            return View();
        }
        #endregion
    }
}
