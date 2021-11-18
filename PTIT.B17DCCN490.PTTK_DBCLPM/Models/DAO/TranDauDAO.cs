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
            List<TranDau> lstTranDau = new List<TranDau>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetTranDausByCauThuGhiBan";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(
                    nameProc,
                    new { _GiaiDauId = giaiDauId.ToString(), _CauThuId = cauThuId.ToString() },
                    commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                lstTranDau = (from DataRow item in tbl.Rows
                              select new TranDau()
                              {
                                  Id = Guid.Parse(item["TranDauId"].ToString()),
                                  DoiNha = new DoiBong_TranDau()
                                  {
                                      DoiBong = new DoiBong_GiaiDau()
                                      {
                                          DoiBong = new DoiBong { Ten = Convert.ToString(item["TenDoiNha"].ToString()) }
                                      }
                                  },
                                  DoiKhach = new DoiBong_TranDau()
                                  {
                                      DoiBong = new DoiBong_GiaiDau()
                                      {
                                          DoiBong = new DoiBong() { Ten = Convert.ToString(item["TenDoiKhach"].ToString()) }
                                      }
                                  }
                              }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write("GetTranDausByCauThuGhiBan", ex.Message);
            }
            return lstTranDau;
        }

        /// <summary>
        /// Lấy danh sách trận đấu theo loại vòng đấu
        /// </summary>
        /// <param name="giaiDauId">Id giải đấu</param>
        /// <param name="loaiVongDauId">Id loại vòng đấu</param>
        /// <returns>Trả về danh sách trận đấu theo loại vòng đấu</returns>
        public List<TranDau> GetTranDausByVongDauGiaiDau(Guid giaiDauId, Guid loaiVongDauId)
        {
            List<TranDau> lstTranDau = new List<TranDau>();
            try
            {
                // tên proc
                string nameProc = "Proc_GetTranDausByVongDauGiaiDau";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(
                    nameProc,
                    new { _GiaiDauId = giaiDauId.ToString(), _LoaiVongDauId = loaiVongDauId.ToString() },
                    commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                lstTranDau = (from DataRow item in tbl.Rows
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
            }
            catch (Exception ex)
            {
                Logger.Write("GetTranDausByVongDauGiaiDau", ex.Message);
            }
            return lstTranDau;
        }

        /// <summary>
        /// Lấy thông tin trận đấu 
        /// </summary>
        /// <param name="id">Id trận đấu</param>
        /// <returns>Trả về thông tin trận đấu</returns>
        public override TranDau GetById(Guid id)
        {
            TranDau objTranDau = new TranDau();
            try
            {
                // tên proc 
                string nameProc = "Proc_GetTranDauById";
                // exe
                var tbl = new DataTable();
                using (var reader = this._mySqlConnection.ExecuteReader(
                    nameProc,
                    new { _TranDauId = id.ToString() },
                    commandType: CommandType.StoredProcedure))
                {
                    tbl.Load(reader);
                }
                // đóng gói
                objTranDau = (from DataRow item in tbl.Rows
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

                               }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.Write("GetByIdTranDau", ex.Message);
            }
            
            return objTranDau;
        }

        /// <summary>
        /// Thêm mới trận đấu
        /// </summary>
        /// <param name="tranDau">Thông tin trận đấu</param>
        /// <returns>Trả về thông tin trận đấu</returns>
        public TranDau InsertTranDau(TranDau tranDau, Guid vongDauId)
        {
            try
            {
                // tên proc
                string nameProc = "Proc_InsertTranDau";
                // tham số đầu vào proc
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_ThoiGianBD", tranDau.ThoiGianBD);
                parameters.Add("_DoiNhaId", tranDau.DoiNha.Id);
                parameters.Add("_DoiKhachId", tranDau.DoiKhach.Id);
                parameters.Add("_VongDauId", vongDauId);
                parameters.Add("_TranDauId", dbType: DbType.Guid, direction: ParameterDirection.Output);
                // mở kết nối
                this._mySqlConnection.Open();
                // exe
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int exe = this._mySqlConnection.Execute(nameProc, parameters, transaction, commandType: CommandType.StoredProcedure);
                    if (exe == 3)
                    {
                        transaction.Commit();
                        tranDau.Id = parameters.Get<Guid>("_TranDauId");
                    }
                    else transaction.Rollback();

                }
            }
            catch (Exception ex)
            {
                Logger.Write("InsertTranDau", ex.Message);
            }
            return tranDau;
        }
        #endregion
    }
}
