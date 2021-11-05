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
        #region Constructor
        public BanToChucDAO(IConfiguration configuration, string nameConnection) : base(configuration, nameConnection)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Kiểm tra đăng nhập
        /// </summary>
        /// <param name="account">Thông tin đăng nhập</param>
        /// <returns>Trả về thông tin ban tổ chức</returns>
        public BanToChuc CheckDangNhap(BanToChuc account)
        {
            try
            {
                // truyền tham số
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_TenDangNhap", account.TenDangNhap);
                parameters.Add("_MatKhau", account.MatKhau);

                // truy vấn kiểm tra đăng nhập
                var banToChuc = this._mySqlConnection.QueryFirstOrDefault<BanToChuc>(sql: "Proc_CheckDangNhap", param: parameters, commandType: CommandType.StoredProcedure);
                return banToChuc;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                this._mySqlConnection.Dispose();
            }
        }
        #endregion
    }
}
