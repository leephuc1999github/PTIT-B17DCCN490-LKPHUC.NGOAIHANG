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
    public class TranDauController : BaseController<TranDau>
    {

        #region Declare
        private readonly ITranDauDAO _tranDauDAO;
        private readonly ICauThuDoiBongTranDauDAO _cauThuDoiBongTranDauDAO;
        private readonly ISuKienDAO _suKienDAO;
        private readonly ILoaiSuKienDAO _loaiSuKienDAO;
        const string _nameConnection = "DefaultConnection";
        #endregion

        #region Constructor
        public TranDauController(IConfiguration configuration) : base(configuration)
        {
            this._tranDauDAO = new TranDauDAO(configuration, _nameConnection);
            this._cauThuDoiBongTranDauDAO = new CauThuDoiBongTranDauDAO(configuration, _nameConnection);
            this._suKienDAO = new SuKienDAO(configuration, _nameConnection);
            this._loaiSuKienDAO = new LoaiSuKienDAO(configuration, _nameConnection);
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
            return View(tranDaus);
        }
        #endregion
    }
}
