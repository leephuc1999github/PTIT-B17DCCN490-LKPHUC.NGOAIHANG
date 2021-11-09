using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTIT.B17DCCN490.PTTK_DBCLPM.Controllers;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.TESTING
{
    [TestClass]
    public class Test_ThongKeController
    {
        private IGiaiDauDAO _giaiDauDAO;
        private IBXHCauThuBanThangDAO _bxhCauThuBanThangDAO;
        private IBXHDAO _bxhDAO;
        private ThongKeController _thongKeController;

        [TestInitialize]
        public void Initialize()
        {
            this._giaiDauDAO = new GiaiDauDAO();
            this._bxhCauThuBanThangDAO = new BXHCauThuBanThangDAO();
            this._bxhDAO = new BXHDAO();
            this._thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO);
        }

        [TestMethod]
        public void Test_Index_WithViewTKCauThuBanThang_NoHasMuaGiai()
        {
            string loai = "goal";
            Guid? muaGiai = new Guid();
            var result = (ViewResult)_thongKeController.Index(loai, muaGiai);
            Assert.AreEqual(loai, result.ViewData["TypeTK"]);
            Assert.AreEqual(muaGiai, result.ViewData["SeasonTK"]);
            var data = (List<BXHCauThuBanThang>)result.ViewData["TKGoal"];
            Assert.AreEqual(0, data.Count());
            Assert.AreEqual("Index", result.ViewName);
        }


        [TestMethod]
        public void Test_Index_WithViewTKCauThuBanThang_NoExistLoaiTK()
        {
            string loai = "demo";
            Guid? muaGiai = new Guid();
            var result = (ViewResult)_thongKeController.Index(loai, muaGiai);
            Assert.AreEqual(loai, result.ViewData["TypeTK"]);
            Assert.AreEqual(muaGiai, result.ViewData["SeasonTK"]);
            var data = (List<BXHCauThuBanThang>)result.ViewData["TKGoal"];
            Assert.AreEqual(0, data.Count());
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
