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

        /// <summary>
        /// Trận đấu không tồn tại, cầu thủ không tồn tại
        /// </summary>
        [TestMethod]
        public void Test_SuKienDAO_1()
        {
            Guid tranDau = new Guid();
            Guid cauThu = new Guid();
            int expect = 0;
            int actual = this.GetSuKiens(tranDau, cauThu).Count();
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        /// Trận đấu không tồn tại, cầu thủ tồn tại
        /// </summary>
        [TestMethod]
        public void Test_SuKienDAO_2()
        {
            Guid tranDau = new Guid();
            Guid cauThu = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            int expect = 0;
            int actual = this.GetSuKiens(tranDau, cauThu).Count();
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        /// Trận đấu tồn tại, cầu thủ không tồn tại trong trận đấu
        /// </summary>
        [TestMethod]
        public void Test_SuKienDAO_3()
        {
            Guid tranDau = new Guid("4a512d0f-327c-11ec-a688-f01faf56e08c");
            Guid cauThu = new Guid("e5a03019-4555-11ec-bdeb-f01faf56e08c");
            int expect = 0;
            int actual = this.GetSuKiens(tranDau, cauThu).Count();
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        /// Trận đấu tồn tại, cầu thủ tồn tại, cầu thủ không ghi bàn 
        /// </summary>
        [TestMethod]
        public void Test_SuKienDAO_4()
        {
            Guid tranDau = new Guid("4a512d0f-327c-11ec-a688-f01faf56e08c");
            Guid cauThu = new Guid("e53005f3-324d-11ec-9f88-f01faf56e08c");
            int expect = 0;
            int actual = this.GetSuKiens(tranDau, cauThu).Count();
            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        /// Trận đấu tồn tại, cầu thủ tồn tại, cầu thủ ghi bàn
        /// </summary>
        [TestMethod]
        public void Test_SuKienDAO_5()
        {
            Guid tranDau = new Guid("4a512d0f-327c-11ec-a688-f01faf56e08c");
            Guid cauThu = new Guid("4d413fba-30da-11ec-be5d-f01faf56e08c");
            int expect = 1;
            int actual = this.GetSuKiens(tranDau, cauThu).Count();
            Assert.AreEqual(expect, actual);
        }
    }
}
