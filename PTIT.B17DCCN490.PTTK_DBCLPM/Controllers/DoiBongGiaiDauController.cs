using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    public class DoiBongGiaiDauController : BaseController<DoiBong_GiaiDau>
    {
        #region Declare
        private readonly IDoiBongGiaiDauDAO _doiBongGiaiDauDAO;
        private readonly IBangDauDAO _bangDauDAO;
        private readonly IDoiBongDAO _doiBongDAO;
        #endregion

        #region Constructor
        public DoiBongGiaiDauController(IDoiBongGiaiDauDAO doiBongGiaiDauDAO,
            IBangDauDAO bangDauDAO,
            IDoiBongDAO doiBongDAO)
        {
            this._doiBongGiaiDauDAO = doiBongGiaiDauDAO;
            this._bangDauDAO = bangDauDAO;
            this._doiBongDAO = doiBongDAO;
        }
        #endregion

        [HttpGet("{id}")]
        public IActionResult GetDoiBongsGiaiDau(Guid id)
        {
            List<DoiBong_GiaiDau> doiBongsGiaiDau = this._doiBongGiaiDauDAO.GetDoiBongsByGiaiDau(id);
            List<BangDau> bangDaus = this._bangDauDAO.GetAll();
            List<SelectListItem> dropdownBangDau = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn bảng đấu", Value = null, Selected = true }
            };
            // options selectbox giải đấu
            dropdownBangDau =
               bangDaus.Select((item, index) => new SelectListItem()
               {
                   Text = item.Ten,
                   Value = item.Id.ToString()
               }).ToList();

            List<DoiBong> doiBongs = this._doiBongDAO.GetAll();
            List<SelectListItem> dropdownDoiBong = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn đội bóng", Value = null, Selected = true }
            };
            // options selectbox giải đấu
            dropdownDoiBong =
               doiBongs.Select((item, index) => new SelectListItem()
               {
                   Text = item.Ten,
                   Value = item.Id.ToString()
               }).ToList();
            ViewBag.BangDaus = dropdownBangDau;
            ViewBag.DoiBongs = dropdownDoiBong;
            ViewBag.GiaiDau = id;
            return View("Index", doiBongsGiaiDau);
        }

        [HttpPost("{id}")]
        public IActionResult InsertDoiBongGiaiDau(Guid id, [FromBody] DoiBong_GiaiDau doiBongGiaiDau)
        {
            bool exe = this._doiBongGiaiDauDAO.InsertDoiBongGiaiDau(id, doiBongGiaiDau);
            return Ok(exe);
        }
    }
}
