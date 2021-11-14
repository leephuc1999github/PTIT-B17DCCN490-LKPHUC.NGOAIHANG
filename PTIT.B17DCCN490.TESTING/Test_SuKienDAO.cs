using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class Test_SuKienDAO
    {
        private ISuKienDAO _suKienDAO;
        private Guid _tranDauId, _cauThuId;

        [TestInitialize]
        public void Initialize()
        {
            this._suKienDAO = new SuKienDAO();
        }

        private List<SuKien> GetSuKiens(Guid tranDauId, Guid cauThuId)
        {
            return this._suKienDAO.GetSuKiensByTranDau(tranDauId)
                        .Where(item => item.CauThu.CauThu.Id == cauThuId &&
                                item.LoaiSuKien.Id == Guid.Parse("3c46f4ee-62ea-5c8d-986f-b9e6bde19f05")).ToList();
        }

        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithExistTranDauIdAndNoHasCauThuId()
        {
            _tranDauId = new Guid("88d1edc8-3278-11ec-a688-f01faf56e08c");
            _cauThuId = new Guid();
            int expect = 8;
            int actual = this.GetSuKiens(_tranDauId, _cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithHasNoTranDauIdAndCauThuId()
        {
            _tranDauId = new Guid();
            _cauThuId = new Guid();
            int expect = 0;
            int actual = this.GetSuKiens(_tranDauId, _cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithNoHasTranDauIdAndExistCauThuId()
        {
            _tranDauId = new Guid();
            _cauThuId = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            int expect = 0;
            int actual = this.GetSuKiens(_tranDauId, _cauThuId).Count();
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void Test_GetSuKiensByTranDau_WithExistTranDauIdAndExistCauThuId()
        {
            _tranDauId = new Guid("88d1edc8-3278-11ec-a688-f01faf56e08c");
            _cauThuId = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            int expect = 0;
            int actual = this.GetSuKiens(_tranDauId, _cauThuId).Count();
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
