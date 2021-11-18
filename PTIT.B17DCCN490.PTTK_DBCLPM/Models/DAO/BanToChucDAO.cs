using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models
{
    public class BanToChucDAO : BaseDAO<BanToChuc>, IBanToChucDAO
    {

        #region Methods
        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <param name="btc">Thông tin đăng nhập</param>
        /// <returns>Trả về thông tin ban tổ chức</returns>
        public BanToChuc CheckDangNhap(BanToChuc btc)
        {
            try
            {
                Logger.Write("CheckDangNhap", "Mes");
                string nameProc = "Proc_CheckDangNhap";
                // truyền tham số
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_TenDangNhap", btc.TenDangNhap);
                parameters.Add("_MatKhau", btc.MatKhau);

                // truy vấn kiểm tra đăng nhập
                var objBTC = this._mySqlConnection
                                 .QueryFirstOrDefault<BanToChuc>
                                 (nameProc, parameters, commandType: CommandType.StoredProcedure);
                return objBTC;
            }
            catch (Exception ex)
            {
                Logger.Write("CheckDangNhap", ex.Message);
                return null;
            }
        }
        #endregion
    }
}
