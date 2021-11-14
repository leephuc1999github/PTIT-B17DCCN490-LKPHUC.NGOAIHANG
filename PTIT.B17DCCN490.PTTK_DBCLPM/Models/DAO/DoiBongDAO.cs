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
    public class DoiBongDAO : BaseDAO<DoiBong>, IDoiBongDAO
    {
        /// <summary>
        /// Lấy danh sách đội bóng
        /// </summary>
        /// <returns>Danh sách đội bóng</returns>
        public override List<DoiBong> GetAll()
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetDoiBongs",
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            List<DoiBong> doiBongs = (from DataRow item in tbl.Rows
                                      select new DoiBong()
                                      {
                                          Id = Guid.Parse(item["Id"].ToString()),
                                          Ten = item["Ten"].ToString(),
                                          SanDau = new SanDau() { Ten = item["TenSanDau"].ToString() }
                                      }).ToList();

            return doiBongs;
        }

        /// <summary>
        /// Thêm mới đội bóng
        /// </summary>
        /// <param name="doiBong">Thông tin đội bóng</param>
        /// <returns>Trả về thành công nếu thêm mới thành công</returns>
        public bool InsertDoiBong(DoiBong doiBong)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("_Ten", doiBong.Ten);
            parameters.Add("_TenSanDau", doiBong.SanDau.Ten);
            parameters.Add("_SoGhe", doiBong.SanDau.SoGhe);
            this._mySqlConnection.Open();
            using (var transaction = this._mySqlConnection.BeginTransaction())
            {
                int rowEffects = this._mySqlConnection.Execute("Proc_InsertDoiBong", parameters, transaction, commandType: CommandType.StoredProcedure);
                if (rowEffects == 2)
                {
                    transaction.Commit();
                    return true;
                }
                else transaction.Rollback();
                return false;
            }
        }
    }
}
