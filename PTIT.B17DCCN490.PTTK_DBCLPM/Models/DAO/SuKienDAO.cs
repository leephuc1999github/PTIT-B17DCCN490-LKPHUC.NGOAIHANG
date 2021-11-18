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
        #region Methods
        /// <summary>
        /// Lấy danh sách sự kiện theo trận đấu
        /// </summary>
        /// <param name="tranDauId">Id trận đấu</param>
        /// <returns>Trả về danh sách sự kiện</returns>
        public List<SuKien> GetSuKiensByTranDau(Guid tranDauId)
        {
            List<SuKien> dienBien = new List<SuKien>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetDienBienByTranDau";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(
                    nameProc,
                    new { _TranDauId = tranDauId.ToString() },
                    commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                dienBien = (from DataRow item in tbl.Rows
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
            }
            catch (Exception ex)
            {
                Logger.Write("GetSuKiensByTranDau", ex.Message);
            }
            return dienBien;
        }

        /// <summary>
        /// Thêm mới sự kiện
        /// </summary>
        /// <param name="suKien">Thông tin sự kiện</param>
        /// <returns>Trả về true nếu thực hiện thành công | Trả về false nếu thức hiện thất bại</returns>
        public bool InsertSuKien(SuKien suKien)
        {
            bool isSuccess = true;
            try
            {
                // tên proc
                string nameProc = "Proc_InsertSuKien";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_ThoiDiem", suKien.ThoiDiem);
                parameters.Add("_LoaiSuKienId", suKien.LoaiSuKien.Id.ToString());
                parameters.Add("_CauThuDoiBongTranDauId", suKien.CauThu.Id.ToString());
                // mở kết nối
                this._mySqlConnection.Open();
                // exe
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int rowEffect = this._mySqlConnection.Execute(nameProc, parameters, transaction, commandType: CommandType.StoredProcedure);
                    if (rowEffect != 1)
                    {
                        transaction.Rollback();
                        isSuccess = false;
                    }
                    else transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.Write("InsertSuKien", ex.Message);
            }
            return isSuccess ? true : false;
        }
        #endregion
    }
}
