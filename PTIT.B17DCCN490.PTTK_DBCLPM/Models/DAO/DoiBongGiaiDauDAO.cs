using Dapper;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO
{
    public class DoiBongGiaiDauDAO : BaseDAO<DoiBong_GiaiDau>, IDoiBongGiaiDauDAO
    {

        /// <summary>
        /// Lấy danh sách đội bóng tham gia giải đấu
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <returns>Trả về danh sách đội bóng giải đấu</returns>
        public List<DoiBong_GiaiDau> GetDoiBongsByGiaiDau(Guid giaiDauId)
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetDoiBongsByGiaiDauId",
                new { _GiaiDauId = giaiDauId },
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            List<DoiBong_GiaiDau> doiBongs = (from DataRow item in tbl.Rows
                                      select new DoiBong_GiaiDau()
                                      {
                                          BangDau = new BangDau() { Ten = item["TenBangDau"].ToString() },
                                          DoiBong = new DoiBong() { Ten = item["TenDoiBong"].ToString() },
                                          Id = Guid.Parse(item["Id"].ToString())
                                      }).ToList();
            return doiBongs;
        }
    }
}
