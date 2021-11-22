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
    public class CauThuController : BaseController<CauThu>
    {
        #region Delcare
        private readonly IDoiBongDAO _doiBongDAO;
        private readonly ICauThuDAO _cauThuDAO;
        #endregion
        public CauThuController(IDoiBongDAO doiBongDAO, ICauThuDAO cauThuDAO)
        {
            this._doiBongDAO = doiBongDAO;
            this._cauThuDAO = cauThuDAO;
        }

        /// <summary>
        /// Giao diện danh sách cầu thủ
        /// </summary>
        /// <returns>Trả về giao diện cầu thủ</returns>
        public override IActionResult Index()
        {
            // get ds đội bóng
            List<DoiBong> lstDoiBong = this._doiBongDAO.GetAll();
            // tạo drop đội bóng
            List<SelectListItem> dropDB = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Chọn đội bóng", Value = null }
            };
            for (int i = 0; i < lstDoiBong.Count(); i++)
            {
                dropDB.Add(new SelectListItem() { Text = lstDoiBong[i].Ten, Value = lstDoiBong[i].Id.ToString() });
            }
            // kiểm tra tham số query string 
            string doiBong = Request.Query["doiBong"];


            List<CauThu> lstCauThu = new List<CauThu>();
            if (string.IsNullOrEmpty(doiBong))
            {
                lstCauThu = this._cauThuDAO.GetAll();
            }
            else
            {
                Guid doiBongId;
                if(!Guid.TryParse(doiBong, out doiBongId))
                {
                    return RedirectToAction("Index", "Loi");
                }
                lstCauThu = this._cauThuDAO.GetCauThusByDoiBong(doiBongId);
            }

            ViewBag.DoiBongs = dropDB;
            // active menu thiết lập
            ViewData["Active"] = "setting";
            ViewData["CurrentTeam"] = doiBong;
            return View("Index", lstCauThu);
        }

        /// <summary>
        /// API thêm mới cầu thủ
        /// </summary>
        /// <param name="id">Id đội bóng</param>
        /// <param name="ct">Thông tin đội bóng</param>
        /// <returns>Trả về kết quả thực hiện</returns>
        [HttpPost("{id}")]
        public IActionResult Insert(Guid id, [FromBody] CauThu ct)
        {
            bool exe = this._cauThuDAO.InsertCauThu(id, ct);
            return Ok(exe);
        }

        /// <summary>
        /// API lấy cầu thủ theo id
        /// </summary>
        /// <param name="id">Id cầu thủ</param>
        /// <returns>Trả về dữ liệu cầu thủ</returns>
        [HttpGet("{id}")]
        public IActionResult GetCauThuById(Guid id)
        {
            var objCT = this._cauThuDAO.GetById(id);
            return Ok(objCT);
        }
    }
}
