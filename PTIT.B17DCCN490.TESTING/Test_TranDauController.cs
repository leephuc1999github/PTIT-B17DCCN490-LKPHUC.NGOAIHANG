using Microsoft.AspNetCore.Http;
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
    public class Test_TranDauController
    {
        private ITranDauDAO _tranDauDAO;
        private ICauThuDoiBongTranDauDAO _cauThuDoiBongTranDauDAO;
        private ISuKienDAO _suKienDAO;
        private ILoaiSuKienDAO _loaiSuKienDAO;
        private IVongDauDAO _vongDauDAO;
        private IDoiBongGiaiDauDAO _doiBongGiaiDauDAO;
        [TestInitialize]
        public void Initialize()
        {
            this._tranDauDAO = new TranDauDAO();
            this._suKienDAO = new SuKienDAO();
        }

        /// <summary>
        /// Mùa giải và cầu thủ = null
        /// </summary>
        [TestMethod]
        public void Test_TranDauController_1()
        {
            var tranDauController = new TranDauController(_tranDauDAO,
            _cauThuDoiBongTranDauDAO,
            _suKienDAO,
            _loaiSuKienDAO,
            _vongDauDAO,
            _doiBongGiaiDauDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            tranDauController.HttpContext.Request.QueryString = new QueryString();
            var actual = tranDauController.Index() as ViewResult;
            // kiểm tra kiểu dữ liệu model
            Assert.AreEqual(typeof(List<TranDau>), actual.Model.GetType());
            var model = actual.Model as List<TranDau>;
            // kiểm tra số lượng bản ghi dữ liệu
            Assert.AreEqual(0, model.Count());
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);
        }


        /// <summary>
        /// Mùa giải không tồn tại, cầu thủ không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_TranDauController_2()
        {
            var tranDauController = new TranDauController(_tranDauDAO,
            _cauThuDoiBongTranDauDAO,
            _suKienDAO,
            _loaiSuKienDAO,
            _vongDauDAO,
            _doiBongGiaiDauDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            tranDauController.HttpContext.Request.QueryString = new QueryString("?cauThu=4d7a58ca-3159-&muaGiai=470dd012-7886-");
            var actual = tranDauController.Index() as ViewResult;
            // kiểm tra giao diện hiển thị
            Assert.AreEqual(null, actual.ViewName);
        }


        /// <summary>
        /// Mùa giải tồn tại, cầu thủ không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_TranDauController_3()
        {
            var tranDauController = new TranDauController(_tranDauDAO,
            _cauThuDoiBongTranDauDAO,
            _suKienDAO,
            _loaiSuKienDAO,
            _vongDauDAO,
            _doiBongGiaiDauDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            tranDauController.HttpContext.Request.QueryString = new QueryString("?cauThu=4d7a58ca-3159-11ec&muaGiai=470dd012-7886-75fc-8186-fecdbcc4765c");
            var actual = tranDauController.Index() as ViewResult;
            // kiểm tra giao diện hiển thị
            Assert.AreEqual(null, actual.ViewName);
        }


        /// <summary>
        /// Mùa giải tồn tại, cầu thủ tồn tại không tham gia giải
        /// </summary>
        [TestMethod]
        public void Test_TranDauController_4()
        {
            var tranDauController = new TranDauController(_tranDauDAO,
            _cauThuDoiBongTranDauDAO,
            _suKienDAO,
            _loaiSuKienDAO,
            _vongDauDAO,
            _doiBongGiaiDauDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            tranDauController.HttpContext.Request.QueryString = new QueryString("?cauThu=e5a03019-4555-11ec-bdeb-f01faf56e08c&muaGiai=470dd012-7886-75fc-8186-fecdbcc4765c");
            var actual = tranDauController.Index() as ViewResult;
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);
        }


        /// <summary>
        /// Mùa giải tồn tại, cầu thủ tồn tại tham gia giải, không có trận đấu kết thúc
        /// </summary>
        [TestMethod]
        public void Test_TranDauController_5()
        {
            var tranDauController = new TranDauController(_tranDauDAO,
            _cauThuDoiBongTranDauDAO,
            _suKienDAO,
            _loaiSuKienDAO,
            _vongDauDAO,
            _doiBongGiaiDauDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            tranDauController.HttpContext.Request.QueryString = new QueryString("?cauThu=e5a03019-4555-11ec-bdeb-f01faf56e08c&muaGiai=af13edf2-315c-11ec-8a5d-f01faf56e08c");
            var actual = tranDauController.Index() as ViewResult;
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);
        }


        /// <summary>
        /// Mùa giải tồn tại, cầu thủ tồn tại tham gia giải, có trận đấu kết thúc có bàn thắng
        /// </summary>
        [TestMethod]
        public void Test_TranDauController_6()
        {
            var tranDauController = new TranDauController(_tranDauDAO,
            _cauThuDoiBongTranDauDAO,
            _suKienDAO,
            _loaiSuKienDAO,
            _vongDauDAO,
            _doiBongGiaiDauDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            tranDauController.HttpContext.Request.QueryString = new QueryString("?cauThu=4d413fba-30da-11ec-be5d-f01faf56e08c&muaGiai=470dd012-7886-75fc-8186-fecdbcc4765c");
            var actual = tranDauController.Index() as ViewResult;
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);
        }
    }
}
