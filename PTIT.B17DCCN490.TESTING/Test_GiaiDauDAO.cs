using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
    public class Test_GiaiDauDAO
    {
        private IGiaiDauDAO _giaiDauDAO;
        [TestInitialize]
        public void Initialize()
        {
            this._giaiDauDAO = new GiaiDauDAO();
        }

        [TestMethod]
        public void Test_GetAllGiaiDau()
        {
            int expect = 3;
            int actual = this._giaiDauDAO.GetAll().Count();
            Assert.AreEqual(expect, actual);
        }
    }
}
