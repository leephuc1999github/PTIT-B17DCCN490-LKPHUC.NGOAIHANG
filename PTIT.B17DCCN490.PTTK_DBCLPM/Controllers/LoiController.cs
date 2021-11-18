using Microsoft.AspNetCore.Mvc;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    public class LoiController : Controller
    {
        /// <summary>
        /// Giao diện lỗi
        /// </summary>
        /// <returns>Trả về giao diện lỗi</returns>
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
