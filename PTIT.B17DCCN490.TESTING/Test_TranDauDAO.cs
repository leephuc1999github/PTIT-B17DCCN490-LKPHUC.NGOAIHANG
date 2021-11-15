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

        /// <summary>
        /// Mùa giải không tồn tại, cầu thủ không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_TranDauDAO_1()
        {
            Guid muaGiai = new Guid();
            Guid cauThu = new Guid();
            var actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(muaGiai, cauThu);
            Assert.AreEqual(0, actual.Count());
        }

        /// <summary>
        /// Mùa giải không tồn tại, cầu thủ tồn tại
        /// </summary>
        [TestMethod]
        public void Test_TranDauDAO_2()
        {
            Guid muaGiai = new Guid();
            Guid cauThu = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            var actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(muaGiai, cauThu);
            Assert.AreEqual(0, actual.Count());
        }

        /// <summary>
        /// Mùa giải tồn tại, cầu thủ không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_TranDauDAO_3()
        {
            Guid muaGiai = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThu = new Guid();
            var actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(muaGiai, cauThu);
            Assert.AreEqual(0, actual.Count());
        }

        /// <summary>
        /// Tồn tại giải đấu, tồn tại cầu thủ, cầu thủ không tham gia giải
        /// </summary>
        [TestMethod]
        public void Test_TranDauDAO_4()
        {
            Guid muaGiai = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThu = new Guid("e5a03019-4555-11ec-bdeb-f01faf56e08c");
            var actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(muaGiai, cauThu);
            Assert.AreEqual(0, actual.Count());
        }


        /// <summary>
        /// Tồn tại giải đấu, tồn tại cầu thủ, cầu thủ không có bàn thắng trong trận đấu
        /// </summary>
        [TestMethod]
        public void Test_TranDauDAO_5()
        {
            Guid muaGiai = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThu = new Guid("0084c3eb-35a2-11ec-982e-f01faf56e08c");
            var actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(muaGiai, cauThu);
            Assert.AreEqual(0, actual.Count());
        }


        /// <summary>
        /// Tồn tại giải đấu, tồn tại cầu thủ, cầu thủ có bàn thắng trong trận đấu
        /// </summary>
        [TestMethod]
        public void Test_TranDauDAO_6()
        {
            Guid muaGiai = new Guid("470dd012-7886-75fc-8186-fecdbcc4765c");
            Guid cauThu = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            var actual = this._tranDauDAO.GetTranDausByCauThuGhiBan(muaGiai, cauThu);
            Assert.AreEqual(8, actual.Count());
        }
    }
}
