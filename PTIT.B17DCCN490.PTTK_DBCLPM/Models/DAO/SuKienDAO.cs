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
    public class SuKienDAO : BaseDAO<SuKien>, ISuKienDAO
    {
        #region Constructor
        public SuKienDAO(IConfiguration configuration, string nameConnection) : base(configuration, nameConnection) 
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách sự kiện theo trận đấu
        /// </summary>
        /// <param name="tranDauId">Id trận đấu</param>
        /// <returns>Trả về danh sách sự kiện</returns>
        public List<SuKien> GetSuKiensByTranDau(Guid tranDauId)
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetDienBienByTranDau",
                new { _TranDauId = tranDauId.ToString() },
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            var suKiens = (from DataRow item in tbl.Rows
                           select new SuKien()
                           {
                               Id = Guid.Parse(item["Id"].ToString()),
                               ThoiDiem = Convert.ToInt32(item["ThoiDiem"].ToString()),
                               CauThu = new CauThu_DoiBong_TranDau()
                               {
                                   Id = Guid.Parse(item["CauThuDoiBongTranDauId"].ToString()),
                                   CauThu = new CauThu() { Id = Guid.Parse(item["CauThuId"].ToString()) }
                               },
                               LoaiSuKien = new LoaiSuKien()
                               {
                                   Id = Guid.Parse(item["LoaiSuKienId"].ToString()),
                                   Ten = item["Ten"].ToString()
                               }
                           }).ToList();
            return suKiens;
        }

        /// <summary>
        /// Thêm mới sự kiện
        /// </summary>
        /// <param name="suKien">Thông tin sự kiện</param>
        /// <returns>Trả về true nếu thực hiện thành công | Trả về false nếu thức hiện thất bại</returns>
        public bool InsertSuKien(SuKien suKien)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_ThoiDiem", suKien.ThoiDiem);
                parameters.Add("_LoaiSuKienId", suKien.LoaiSuKien.Id.ToString());
                parameters.Add("_CauThuDoiBongTranDauId", suKien.CauThu.Id.ToString());
                this._mySqlConnection.Open();
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int rowEffect = this._mySqlConnection.Execute("Proc_InsertSuKien", parameters, transaction, commandType: CommandType.StoredProcedure);
                    if (rowEffect == 1) transaction.Commit();
                    return rowEffect == 1 ? true : false;
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
