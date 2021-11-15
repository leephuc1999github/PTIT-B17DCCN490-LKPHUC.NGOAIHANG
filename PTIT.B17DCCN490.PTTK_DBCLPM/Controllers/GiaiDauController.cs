﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
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
        #region Declare
        private readonly IGiaiDauDAO _giaiDauDAO;
        #endregion

        #region Constructor
        public GiaiDauController(IGiaiDauDAO giaiDauDAO)
        {
            this._giaiDauDAO = giaiDauDAO;
        }
        #endregion
        public override IActionResult Index()
        {
            ViewData["Active"] = "setting";
            return base.Index();
        }

        [HttpPost]
        public IActionResult InsertGiaiDau([FromBody] GiaiDau giaiDau)
        {
            int exe = this._giaiDauDAO.Insert(giaiDau);
            return Ok(exe);
        }
    }
}