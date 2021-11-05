using Microsoft.Extensions.Configuration;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO
{
    public class GiaiDauDAO : BaseDAO<GiaiDau>, IGiaiDauDAO
    {
        #region Declare
        public GiaiDauDAO(IConfiguration configuration, string nameConnection) : base(configuration, nameConnection)
        {

        }
        #endregion
    }
}
