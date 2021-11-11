using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Authorize(Roles = "admin")]
    public class GiaiDauController : BaseController<GiaiDau>
    {
        public override IActionResult Index()
        {
            ViewData["Active"] = "setting";
            return base.Index();
        }
    }
}
