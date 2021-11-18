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

        #region Methods
        /// <summary>
        /// Danh sách đội bóng tham gia giải
        /// </summary>
        /// <param name="id">Id giải đấu</param>
        /// <returns>Giao diện đội bóng giải đấu</returns>
        [HttpGet("{id}")]
        public IActionResult GetDoiBongsGiaiDau(Guid id)
        {
            // đội bóng đã đăng ký tham gia
            List<DoiBong_GiaiDau> lstDoiBongDaDangKy = this._doiBongGiaiDauDAO.GetDoiBongsByGiaiDau(id);
            // ds bảng đấu
            List<BangDau> lstBangDau = this._bangDauDAO.GetAll();
            // ds đội bóng
            List<DoiBong> doiBongs = this._doiBongDAO.GetAll();

            // options selectbox bảng đấu
            List<SelectListItem> dropBD = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn bảng đấu", Value = null, Selected = true }
            };
            dropBD = lstBangDau.Select((item, index) => new SelectListItem()
                                        {
                                            Text = item.Ten,
                                            Value = item.Id.ToString()
                                        }).ToList();

            // options selectbox đội bóng
            List<SelectListItem> dropDB = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn đội bóng", Value = null, Selected = true }
            };
            dropDB = doiBongs.Select((item, index) => new SelectListItem()
                                    {
                                        Text = item.Ten,
                                        Value = item.Id.ToString()
                                    }).ToList();
            ViewBag.BangDaus = dropBD;
            ViewBag.DoiBongs = dropDB;
            ViewBag.GiaiDau = id;
            return View("Index", lstDoiBongDaDangKy);
        }

        /// <summary>
        /// Đăng ký tham giai giải
        /// </summary>
        /// <param name="id">Id giải đấu</param>
        /// <param name="doiBongGiaiDau">Danh sách đội bóng tham gia</param>
        /// <returns>Trạng thái thực hiện</returns>
        [HttpPost("{id}")]
        public IActionResult InsertDoiBongGiaiDau(Guid id, [FromBody] DoiBong_GiaiDau doiBongGiaiDau)
        {
            bool exe = this._doiBongGiaiDauDAO.InsertDoiBongGiaiDau(id, doiBongGiaiDau);
            return Ok(exe);
        }
        #endregion
    }
}
