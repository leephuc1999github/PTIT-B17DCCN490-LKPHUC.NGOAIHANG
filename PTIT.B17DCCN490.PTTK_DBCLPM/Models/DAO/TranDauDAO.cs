using Dapper;
using Microsoft.Extensions.Configuration;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO.Services;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.DAO
{
    public class TranDauDAO : BaseDAO<TranDau>, ITranDauDAO
    {

        #region Methods
        /// <summary>
        /// Lấy danh sách trận đấu theo cầu thủ ghi bàn
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <param name="cauThuId">Id cầu thủ</param>
        /// <returns>Trả về danh sách trận đấu cầu thủ ghi bàn</returns>
        public List<TranDau> GetTranDausByCauThuGhiBan(Guid giaiDauId, Guid cauThuId)
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetTranDausByCauThuGhiBan",
                new { _GiaiDauId = giaiDauId.ToString(), _CauThuId = cauThuId.ToString() },
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            List<TranDau> tranDaus = (from DataRow item in tbl.Rows
                                      select new TranDau()
                                      {
                                          Id = Guid.Parse(item["TranDauId"].ToString()),
                                          DoiNha = new DoiBong_TranDau()
                                          {
                                              DoiBong = new DoiBong_GiaiDau() 
                                              { 
                                                  DoiBong = new DoiBong { Ten = Convert.ToString(item["TenDoiThu"].ToString()) } 
                                              }
                                          }
                                      }).ToList();

            return tranDaus;
        }

        /// <summary>
        /// Lấy danh sách trận đấu theo loại vòng đấu
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <param name="loaiVongDauId">Id loại vòng đấu</param>
        /// <returns>Trả về danh sách trận đấu theo loại vòng đấu</returns>
        public List<TranDau> GetTranDausByVongDauGiaiDau(Guid giaiDauId, Guid loaiVongDauId)
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetTranDausByVongDauGiaiDau",
                new { _GiaiDauId = giaiDauId.ToString(), _LoaiVongDauId = loaiVongDauId.ToString() },
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            List<TranDau> tranDaus = (from DataRow item in tbl.Rows
                                      select new TranDau()
                                      {
                                          Id = Guid.Parse(item["Id"].ToString()),
                                          ThoiGianBD = Convert.ToDateTime(item["ThoiGianBD"].ToString()),
                                          DaKetThuc = item["DaKetThuc"].ToString() == "1" ? true : false,
                                          DangDienRa = item["DangDienRa"].ToString() == "1" ? true : false,
                                          DoiNha = new DoiBong_TranDau()
                                          {
                                              DoiBong = new DoiBong_GiaiDau() 
                                              {
                                                  DoiBong = new DoiBong() { Ten = item["DoiNha"].ToString() }
                                              },
                                              SoBanThang = Convert.ToInt32(item["SBTDoiNha"].ToString())
                                          },
                                          DoiKhach = new DoiBong_TranDau()
                                          {
                                              DoiBong = new DoiBong_GiaiDau() 
                                              {
                                                  DoiBong = new DoiBong() { Ten = item["DoiKhach"].ToString() }
                                              },
                                              SoBanThang = Convert.ToInt32(item["SBTDoiKhach"].ToString())
                                          }
                                      }).ToList();

            return tranDaus;
        }

        /// <summary>
        /// Lấy thông tin trận đấu 
        /// </summary>
        /// <param name="id">Id trận đấu</param>
        /// <returns>Trả về thông tin trận đấu</returns>
        public override TranDau GetById(Guid id)
        {
            var tbl = new DataTable();
            using (var reader = this._mySqlConnection.ExecuteReader(
                "Proc_GetTranDauById",
                new { _TranDauId = id.ToString() },
                commandType: CommandType.StoredProcedure))
            {
                tbl.Load(reader);
            }
            var tranDau = (from DataRow item in tbl.Rows
                           select new TranDau()
                           {
                               Id = Guid.Parse(item["Id"].ToString()),
                               ThoiGianBD = Convert.ToDateTime(item["ThoiGianBD"].ToString()),
                               DaKetThuc = item["DaKetThuc"].ToString() == "1" ? true : false,
                               DangDienRa = item["DangDienRa"].ToString() == "1" ? true : false,
                               DoiNha = new DoiBong_TranDau()
                               {
                                   Id = Guid.Parse(item["DoiNhaTranDauId"].ToString()),
                                   DoiBong = new DoiBong_GiaiDau()
                                   {
                                       DoiBong = new DoiBong() 
                                       {
                                           Ten = item["DoiNha"].ToString(),
                                           Id = Guid.Parse(item["DoiNhaId"].ToString())
                                       }
                                   },
                                   SoBanThang = Convert.ToInt32(item["SBTDoiNha"].ToString())
                               },
                               DoiKhach = new DoiBong_TranDau()
                               {
                                   Id = Guid.Parse(item["DoiKhachTranDauId"].ToString()),
                                   DoiBong = new DoiBong_GiaiDau() 
                                   { 
                                       DoiBong = new DoiBong() 
                                       { 
                                           Ten = item["DoiKhach"].ToString(), 
                                           Id = Guid.Parse(item["DoiKhachId"].ToString()) 
                                       } 
                                   },
                                   SoBanThang = Convert.ToInt32(item["SBTDoiKhach"].ToString())
                               }

                           }).ToList();
            return tranDau.Count() == 0 ? null : tranDau[0];
        }
        #endregion
    }
}
