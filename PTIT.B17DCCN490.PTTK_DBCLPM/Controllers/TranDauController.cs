using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    [Authorize(Roles = "admin")]
    public class TranDauController : BaseController<TranDau>
    {

        #region Declare
        private readonly ITranDauDAO _tranDauDAO;
        private readonly ICauThuDoiBongTranDauDAO _cauThuDoiBongTranDauDAO;
        private readonly ISuKienDAO _suKienDAO;
        private readonly ILoaiSuKienDAO _loaiSuKienDAO;
        private readonly IVongDauDAO _vongDauDAO;
        private readonly IDoiBongGiaiDauDAO _doiBongGiaiDauDAO;

        #endregion

        #region Constructor
        public TranDauController(ITranDauDAO tranDauDAO,
            ICauThuDoiBongTranDauDAO cauThuDoiBongTranDauDAO,
            ISuKienDAO suKienDAO,
            ILoaiSuKienDAO loaiSuKienDAO, 
            IVongDauDAO vongDauDAO, 
            IDoiBongGiaiDauDAO doiBongGiaiDauDAO)
        {
            this._tranDauDAO = tranDauDAO;
            this._cauThuDoiBongTranDauDAO = cauThuDoiBongTranDauDAO;
            this._suKienDAO = suKienDAO;
            this._loaiSuKienDAO = loaiSuKienDAO;
            this._vongDauDAO = vongDauDAO;
            this._doiBongGiaiDauDAO = doiBongGiaiDauDAO;

        }
        #endregion

        #region Methods
        [HttpGet("Edit/{id}")]
        public override IActionResult Edit(Guid id)
        {
            TranDau tranDau = this._tranDauDAO.GetById(id);
            tranDau.DoiNha.CauThus = this._cauThuDoiBongTranDauDAO.GetCauThusByDoiBongTranDau(tranDau.DoiNha.Id);
            tranDau.DoiKhach.CauThus = this._cauThuDoiBongTranDauDAO.GetCauThusByDoiBongTranDau(tranDau.DoiKhach.Id);
            List<SuKien> suKiens = this._suKienDAO.GetSuKiensByTranDau(id);
            List<SelectListItem> dropdownLoaiSuKien =
                this._loaiSuKienDAO.GetAll().Select((item, index) => new SelectListItem()
                {
                    Text = item.Ten,
                    Value = item.Id.ToString(),
                }).ToList();
            HashSet<int> thoiDiems = new HashSet<int>();
            List<SuKien> temp = new List<SuKien>();
            List<KeyValuePair<int, List<SuKien>>> mappingSuKienCauThu = new List<KeyValuePair<int, List<SuKien>>>();
            foreach (var item in suKiens)
            {
                if (!thoiDiems.Contains(item.ThoiDiem))
                {
                    temp = new List<SuKien>();
                    temp.Add(item);
                    mappingSuKienCauThu.Add(new KeyValuePair<int, List<SuKien>>(item.ThoiDiem, temp));
                    thoiDiems.Add(item.ThoiDiem);
                }
                else
                {
                    temp = mappingSuKienCauThu.FirstOrDefault(element => element.Key.Equals(item.ThoiDiem)).Value;
                    temp.Add(item);
                    mappingSuKienCauThu.Remove(mappingSuKienCauThu.Where(element => element.Key.Equals(item.ThoiDiem)).FirstOrDefault());
                    mappingSuKienCauThu.Add(new KeyValuePair<int, List<SuKien>>(item.ThoiDiem, temp));
                }
            }
            mappingSuKienCauThu.Sort((x, y) => x.Key.CompareTo(y.Key));
            ViewData["SuKien"] = mappingSuKienCauThu;
            ViewBag.LoaiSuKiens = dropdownLoaiSuKien;
            return View(tranDau);
        }


        public override IActionResult Add()
        {
            string giaiDauId = Request.Cookies["GiaiDauId"];
            ViewData["DoiBongGiaiDau"] = this._doiBongGiaiDauDAO.GetDoiBongsByGiaiDau(Guid.Parse(giaiDauId));
            return base.Add();
        }

        [HttpPost]
        public IActionResult Insert(TranDau tranDau)
        {
            string giaiDauId = Request.Cookies["GiaiDauId"];
            string loaiVongDauId = Request.Cookies["LoaiVongDauId"];
            VongDau vongDau = this._vongDauDAO.GetVongDauByGiaiDauAndLoaiVongDau(Guid.Parse(loaiVongDauId), Guid.Parse(giaiDauId));
            tranDau = this._tranDauDAO.InsertTranDau(tranDau, vongDau.Id);
            return RedirectToAction("Edit", new { id = tranDau.Id });
        }
        public override IActionResult Index()
        {
            // query string : cauThuId && giaiDauId
            string muaGiai = HttpContext.Request.Query["muaGiai"];
            string cauThu = HttpContext.Request.Query["cauThu"];
            List<TranDau> tranDaus = new List<TranDau>();
            if (muaGiai != null && cauThu != null)
            {
                // mapping trận đấu và thời điểm ghi bàn của cầu thủ
                Dictionary<TranDau, List<SuKien>> mappingTDSKs = new Dictionary<TranDau, List<SuKien>>();
                // danh sách trận đấu cầu thủ ghi bàn
                tranDaus = this._tranDauDAO.GetTranDausByCauThuGhiBan(Guid.Parse(muaGiai), Guid.Parse(cauThu));
                for(int i = 0; i < tranDaus.Count(); i++)
                {
                    TranDau tranDau = tranDaus[i];
                    // danh sách bàn thắng của trận đấu
                    List<SuKien> suKiens = this._suKienDAO.GetSuKiensByTranDau(tranDau.Id)
                                                            .Where(item => item.CauThu.CauThu.Id == Guid.Parse(cauThu) 
                                                                            && item.LoaiSuKien.Id == Guid.Parse("3c46f4ee-62ea-5c8d-986f-b9e6bde19f05"))
                                                            .ToList();
                    mappingTDSKs.Add(tranDau, suKiens);
                }
                ViewData["TDSKS"] = mappingTDSKs;
            }
            return View("Index", tranDaus);
        }
        #endregion
    }
}
