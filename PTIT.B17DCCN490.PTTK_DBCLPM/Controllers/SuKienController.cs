using Microsoft.AspNetCore.Mvc;
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
    public class SuKienController : BaseController<SuKien>
    {
        #region Declare
        private readonly ISuKienDAO _suKienDAO;
        #endregion

        #region Constructor
        public SuKienController(ISuKienDAO suKienDAO)
        {
            this._suKienDAO = suKienDAO;
        }
        #endregion

        #region Methods
        [HttpPost]
        public IActionResult Insert([FromBody] SuKien data)
        {
            bool exe = this._suKienDAO.InsertSuKien(data);
            return Ok(exe);
        }
        #endregion
    }
}
