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
    public class Test_SuKienDAO
    {
        private ISuKienDAO _suKienDAO;
        [TestInitialize]
        public void Initialize()
        {
            this._suKienDAO = new SuKienDAO();
        }

        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithExistTranDauId()
        {
            Guid tranDauId = new Guid("88d1edc8-3278-11ec-a688-f01faf56e08c");
            int expect = 8;
            int actual = this._suKienDAO.GetSuKiensByTranDau(tranDauId).Count();
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithHasNoTranDauId()
        {
            Guid tranDauId = new Guid();
            int expect = 0;
            int actual = this._suKienDAO.GetSuKiensByTranDau(tranDauId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithExistTranDauIdNoEvent()
        {
            Guid tranDauId = new Guid("add4e2de-3273-11ec-a688-f01faf56e08c");
            int expect = 0;
            int actual = this._suKienDAO.GetSuKiensByTranDau(tranDauId).Count();
            Assert.AreEqual(expect, actual);
        }
    }
}
