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
    public class TestUserDAO
    {
        private IUserDAO _userDAO;
        private IConfiguration _configuration;

        public TestUserDAO()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(Configuration);
        }

        public IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
                    _configuration = builder.Build();
                }

                return _configuration;
            }
        }


        [TestInitialize]
        public void Initialize()
        {
            this._userDAO = new UserDAO(_configuration, "TestConnection");
        }

        [TestMethod]
        public void TestCheckConneciton()
        {
            var actual = this._userDAO.CheckConnection();
            Assert.AreEqual(15, actual.Count());
        }
    }
}
