using Microsoft.AspNetCore.Mvc;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    public class DoiBongController : BaseController<DoiBong>
    {
        #region Declare
        private readonly IDoiBongDAO _doiBongDAO;
        #endregion

        #region Constructor
        public DoiBongController(IDoiBongDAO doiBongDAO)
        {
            this._doiBongDAO = doiBongDAO;
        }
        #endregion

        public override IActionResult Index()
        {
            List<DoiBong> doiBongs = this._doiBongDAO.GetAll();
            ViewData["Active"] = "setting";
            return View("Index", doiBongs);
        }

        [HttpPost]
        public IActionResult InsertDoiBong([FromBody] DoiBong doiBong)
        {
            bool exe = this._doiBongDAO.InsertDoiBong(doiBong);
            return Ok(exe);
        }
    }
}
