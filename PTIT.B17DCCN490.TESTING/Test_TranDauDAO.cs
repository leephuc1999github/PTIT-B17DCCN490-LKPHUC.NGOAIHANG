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
    public class Test_TranDauDAO
    {
        private ITranDauDAO _tranDauDAO;
        [TestInitialize]
        public void Initialize()
        {
            this._tranDauDAO = new TranDauDAO();
        }

        [TestMethod]
        public void Test_GetTranDausByCauThuGhiBan_WithExistGiaiDauIdAndCauThuIdHasRanking()
        {
            Guid giaiDauId = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThuId = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            int expect = 3;
            int actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(giaiDauId, cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetTranDausByCauThuGhiBan_WithExistGiaiDauIdAndNoCauThuId()
        {
            Guid giaiDauId = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThuId = new Guid();
            int expect = 0;
            int actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(giaiDauId, cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetTranDausByCauThuGhiBan_WithNoGiaiDauIdAndExistCauThuId()
        {
            Guid giaiDauId = new Guid();
            Guid cauThuId = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            int expect = 0;
            int actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(giaiDauId, cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetTranDausByCauThuGhiBan_WithNoExistGiaiDauIdAndCauThuId()
        {
            Guid giaiDauId = new Guid();
            Guid cauThuId = new Guid();
            int expect = 0;
            int actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(giaiDauId, cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetTranDausByCauThuGhiBan_WithGiaiDauIdAndCauThuIdNoRanking()
        {
            Guid giaiDauId = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThuId = new Guid("5593a690-357a-11ec-982e-f01faf56e08c");
            int expect = 0;
            int actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(giaiDauId, cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }
    }
}
