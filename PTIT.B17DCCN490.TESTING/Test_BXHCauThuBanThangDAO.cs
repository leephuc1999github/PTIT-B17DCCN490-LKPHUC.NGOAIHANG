using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.TESTING
{
    [TestClass]
    public class Test_BXHCauThuBanThangDAO
    {
        private IBXHCauThuBanThangDAO _bxhCauThuBanThangDAO;
        [TestInitialize]
        public void Initialize()
        {
            this._bxhCauThuBanThangDAO = new BXHCauThuBanThangDAO();
        }

        #region Test kiểm tra với dữ liệu đầu vào
        [TestMethod]
        public void Test_GetTKCauThuBanThangDAO_WithExistGiaiDauId_NoData()
        {
            Guid giaiDauId = new Guid("af13edf2-315c-11ec-8a5d-f01faf56e08c");
            int expect = 0;
            int actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(giaiDauId).Count();
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void Test_GetTKCauThuBanThangDAO_WithExistGiaiDauId_HasData()
        {
            Guid giaiDauId = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            int expect = 70;
            int actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(giaiDauId).Count();
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void Test_GetTKCauThuBanThangDAO_WithInValidGiaiDauId()
        {
            Guid giaiDauId = new Guid();
            int expect = 0;
            int actual = this._bxhCauThuBanThangDAO.GetTKCauThuBangThangs(giaiDauId).Count();
            Assert.AreEqual(expect, actual);
        }
        #endregion
    }
}
