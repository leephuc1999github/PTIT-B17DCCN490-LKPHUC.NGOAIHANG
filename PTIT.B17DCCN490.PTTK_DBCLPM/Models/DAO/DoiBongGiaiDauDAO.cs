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
            List<DoiBong_GiaiDau> lstDoiBongThamGiaGiai = new List<DoiBong_GiaiDau>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetDoiBongsByGiaiDauId";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(
                    nameProc,
                    new { _GiaiDauId = giaiDauId },
                    commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                lstDoiBongThamGiaGiai = (from DataRow item in tbl.Rows
                                         select new DoiBong_GiaiDau()
                                         {
                                             BangDau = new BangDau() { Ten = item["TenBangDau"].ToString() },
                                             DoiBong = new DoiBong() { Ten = item["TenDoiBong"].ToString() },
                                             Id = Guid.Parse(item["Id"].ToString())
                                         }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write("GetDoiBongsByGiaiDau", ex.Message);
            }
            return lstDoiBongThamGiaGiai;
        }

        /// <summary>
        /// Thêm mới đội bóng giải đấu
        /// </summary>
        /// <param name="doiBongGiaiDau">Thông tin đội bóng giải đấu</param>
        /// <returns>Trả về true nếu thực hiện thành công</returns>
        public bool InsertDoiBongGiaiDau(Guid id, DoiBong_GiaiDau doiBongGiaiDau)
        {
            bool isSuccess = true;
            try
            {
                // tên proc
                string nameProc = "Proc_InsertDoiBongGiaiDau";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_GiaiDauId", id);
                parameters.Add("_BangDauId", doiBongGiaiDau.BangDau.Id);
                parameters.Add("_DoiBongId", doiBongGiaiDau.DoiBong.Id);
                // mở kết nối
                this._mySqlConnection.Open();
                // exe
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int exe = this._mySqlConnection.Execute(nameProc, parameters, transaction, commandType: CommandType.StoredProcedure);
                    if (exe == 1) transaction.Commit();
                    else
                    {
                        transaction.Rollback();
                        isSuccess = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write("InsertDoiBongGiaiDau", ex.Message);
            }
            return isSuccess ? true : false;
        }
    }
}
