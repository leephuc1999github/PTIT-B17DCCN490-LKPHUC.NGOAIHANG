using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTIT.B17DCCN490.PTTK_DBCLPM.Controllers;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PTIT.B17DCCN490.TESTING
{
    [TestClass]
    public class Test_ThongKeController
    {
        private IGiaiDauDAO _giaiDauDAO;
        private IBXHCauThuBanThangDAO _bxhCauThuBanThangDAO;
        private IBXHDAO _bxhDAO;
        private ThongKeController _thongKeController;
        const string _host = "https://localhost:44352/";

        [TestInitialize]
        public void Initialize()
        {
            this._giaiDauDAO = new GiaiDauDAO();
            this._bxhCauThuBanThangDAO = new BXHCauThuBanThangDAO();
            this._bxhDAO = new BXHDAO();
        }

        /// <summary>
        /// Loại thống kê và mùa giải = null
        /// </summary>
        [TestMethod]
        public void Test_ThongKeController_1()
        {
            var thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            thongKeController.HttpContext.Request.QueryString = new QueryString();
            var actual = thongKeController.Index() as ViewResult;
            var dopdownList = actual.ViewData["GiaiDaus"] as List<SelectListItem>;
            // kiểm tra loại thống kê
            Assert.AreEqual("result", actual.ViewData["TypeTK"]);
            // kiểm tra dữ liệu dropdown list
            Assert.AreEqual(3, dopdownList.Count());
            // kiểm tra giá trị được active trong dropdown list
            Assert.AreEqual(dopdownList[0].Value, actual.ViewData["CurrentSeason"]);
            // kiểm tra dữ liệu bảng hiển thị
            Assert.AreEqual(typeof(List<BXH>), actual.ViewData["TKResult"].GetType());
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);

        }

        /// <summary>
        /// Loại thống kê không chính xác, mùa giải không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_ThongKeControlelr_2()
        {
            var thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            thongKeController.HttpContext.Request.QueryString = new QueryString("?loai=abc&&muaGiai=7945245");
            var actual = thongKeController.Index() as ViewResult;
            // trả về giao diện lỗi
            Assert.AreEqual(null, actual);
        }


        /// <summary>
        /// Loại thống kê không chính xác, mùa giải tồn tại
        /// </summary>
        [TestMethod]
        public void Test_ThongKeControlelr_3()
        {
            var thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            thongKeController.HttpContext.Request.QueryString = new QueryString("?loai=abc&&muaGiai=470dd012-7886-75fc-8186-fecdbcc4765c");
            var actual = thongKeController.Index() as ViewResult;
            // trả về giao diện lỗi
            Assert.AreEqual(null, actual);
        }


        /// <summary>
        /// Loại thống kê chính xác, mùa giải không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_ThongKeControlelr_4()
        {
            var thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            thongKeController.HttpContext.Request.QueryString = new QueryString("?loai=goal&&muaGiai=470dd012c");
            var actual = thongKeController.Index() as ViewResult;
            // trả về giao diện lỗi
            Assert.AreEqual(null, actual);
        }


        /// <summary>
        /// Loại thống kê chính xác, mùa giải tồn tại, không có cầu thủ ghi bàn
        /// </summary>
        [TestMethod]
        public void Test_ThongKeControlelr_5()
        {
            var thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            thongKeController.HttpContext.Request.QueryString = new QueryString("?loai=goal&&muaGiai=af13edf2-315c-11ec-8a5d-f01faf56e08c");
            var actual = thongKeController.Index() as ViewResult;
            var dopdownList = actual.ViewData["GiaiDaus"] as List<SelectListItem>;
            var data = actual.ViewData["TKGoal"];
            // kiểm tra loại thống kê
            Assert.AreEqual("goal", actual.ViewData["TypeTK"]);
            // kiểm tra dữ liệu dropdown list
            Assert.AreEqual(3, dopdownList.Count());
            // kiểm tra giá trị được active trong dropdown list
            Assert.AreEqual("af13edf2-315c-11ec-8a5d-f01faf56e08c", actual.ViewData["CurrentSeason"]);
            // kiểm tra dữ liệu bảng hiển thị
            Assert.AreEqual(typeof(List<BXHCauThuBanThang>), data.GetType());
            var bxh = data as List<BXHCauThuBanThang>;
            // kiểm tra số lượng bản ghi trả về
            Assert.AreEqual(0, bxh.Count());
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);
        }


        /// <summary>
        /// Loại thống kê chính xác, mùa giải tồn tại, có cầu thủ ghi bàn
        /// </summary>
        [TestMethod]
        public void Test_ThongKeControlelr_6()
        {
            var thongKeController = new ThongKeController(_giaiDauDAO, _bxhCauThuBanThangDAO, _bxhDAO)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            thongKeController.HttpContext.Request.QueryString = new QueryString("?loai=goal&&muaGiai=470dd012-7886-75fc-8186-fecdbcc4765c");
            var actual = thongKeController.Index() as ViewResult;
            var dopdownList = actual.ViewData["GiaiDaus"] as List<SelectListItem>;
            var data = actual.ViewData["TKGoal"];
            // kiểm tra loại thống kê
            Assert.AreEqual("goal", actual.ViewData["TypeTK"]);
            // kiểm tra dữ liệu dropdown list
            Assert.AreEqual(3, dopdownList.Count());
            // kiểm tra giá trị được active trong dropdown list
            Assert.AreEqual("470dd012-7886-75fc-8186-fecdbcc4765c", actual.ViewData["CurrentSeason"]);
            // kiểm tra dữ liệu bảng hiển thị
            Assert.AreEqual(typeof(List<BXHCauThuBanThang>), data.GetType());
            var bxh = data as List<BXHCauThuBanThang>;
            // kiểm tra số lượng bản ghi trả về
            Assert.AreEqual(160, bxh.Count());
            // kiểm tra giao diện hiển thị
            Assert.AreEqual("Index", actual.ViewName);
        }
    }
}
