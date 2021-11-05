using Dapper;
using Microsoft.Extensions.Configuration;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO
{
    public class CauThuDoiBongTranDauDAO : BaseDAO<CauThu_DoiBong_TranDau>, ICauThuDoiBongTranDauDAO
    {
        #region Constructor
        public CauThuDoiBongTranDauDAO(IConfiguration configuration, string nameConnection) : base(configuration, nameConnection)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Danh sách đăng ký cầu thủ trận đấu
        /// </summary>
        /// <param name="doiBongTranDauId">Id đội bóng trận đấu</param>
        /// <returns>Danh sách cầu thủ</returns>
        public List<CauThu_DoiBong_TranDau> GetCauThusByDoiBongTranDau(Guid doiBongTranDauId)
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetCauThusByDoiBongTranDauId",
                new { _DoiBongTranDauId = doiBongTranDauId.ToString() },
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            var cauThus = (from DataRow item in tbl.Rows
                           select new CauThu_DoiBong_TranDau()
                           {
                               Id = Guid.Parse(item["Id"].ToString()),
                               IsDaChinh = item["IsDaChinh"].ToString() == "1" ? true : false,
                               CauThu = new CauThu()
                               {
                                   Id = Guid.Parse(item["CauThuId"].ToString()),
                                   Ten = item["Ten"].ToString(),
                                   SoAo = Convert.ToInt32(item["SoAo"].ToString())
                               }
                           }).ToList();
            return cauThus;
        }

        /// <summary>
        /// Đăng ký danh sách câu thủ tham gia trận đấu
        /// </summary>
        /// <param name="cauThus">Danh sách cầu thủ trận đấu</param>
        /// <param name="doiBongTranDauId">Id đội bóng trận đấu</param>
        /// <returns>Trả về true nếu thêm thành công | Trả về false nếu thêm thất bại</returns>
        public bool RegisterCauThusByDoiBongTranDau(Guid doiBongTranDauId, List<CauThu_DoiBong_TranDau> cauThus)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_DoiBongTranDauId", doiBongTranDauId.ToString());
                this._mySqlConnection.Open();
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int clear = this._mySqlConnection.Execute("Proc_DeleteCauThuDoiBongTranDauByDoiBongTranDauId", parameters, transaction, commandType: CommandType.StoredProcedure);
                    foreach (var item in cauThus)
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("_DoiBongTranDauId", doiBongTranDauId.ToString());
                        parameters.Add("_CauThuId", item.CauThu.Id.ToString());
                        parameters.Add("_IsDaChinh", item.IsDaChinh);
                        int rowEffect = this._mySqlConnection.Execute("Proc_InsertCauThuDoiBongTranDau", parameters, transaction, commandType: CommandType.StoredProcedure);
                        if (rowEffect == 0)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion
    }
}
