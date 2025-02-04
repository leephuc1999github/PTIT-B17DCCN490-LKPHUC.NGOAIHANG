﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ENUM;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Authorize(Roles = "admin")]
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
        /// <summary>
        /// Thêm mới sự kiện
        /// </summary>
        /// <param name="data">Thông tin sự kiện</param>
        /// <returns>Trạng thái thực hiện</returns>
        [HttpPost]
        public IActionResult Insert([FromBody] SuKien data)
        {
            bool exe = this._suKienDAO.InsertSuKien(data);
            return Ok(exe);
        }
        #endregion
    }
}
