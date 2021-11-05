using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Authorize(Roles = "admin")]
    public class TrangChuController : Controller
    {
        public IActionResult Index()
        {
            foreach (var item in User.Claims)
            {
                string type = item.Type;
                string value = item.Value;
            }
            ViewData["Active"] = "home";
            return View();
        }
    }
}
