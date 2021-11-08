using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models
{
    public class BaseDAO<T> : IBaseDAO<T>, IDisposable where T : class
    {
        #region Declare
        private string _connectString;
        protected MySqlConnection _mySqlConnection;
        private string _nameTable;
        #endregion

        #region Constructor
        public BaseDAO()
        {
            this._connectString = "User Id=root;Host=localhost;Database=b17dccn490_lkphuc_pttkdbclpm;Character Set=utf8";
            this._mySqlConnection = new MySqlConnection(this._connectString);
            this._nameTable = typeof(T).Name;
        }

        public BaseDAO(string connectString)
        {
            this._connectString = connectString;
            this._mySqlConnection = new MySqlConnection(this._connectString);
            this._nameTable = typeof(T).Name;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Ngắt kết nối 
        /// </summary>
        public void Dispose()
        {
            this._mySqlConnection.Dispose();
        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <returns>Trả về 1 nếu thêm thành công || trả về 0 nếu thêm thất bại</returns>
        public virtual int Insert(T entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                string nameProc = $"Proc_Insert{_nameTable}";
                foreach (PropertyInfo prop in entity.GetType().GetProperties())
                {
                    var value = prop.GetValue(entity) == "" ? null : prop.GetValue(entity);
                    parameters.Add($"_{prop.Name}", value);
                }
                this._mySqlConnection.Open();
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int rowAffects = this._mySqlConnection.Execute(nameProc, param: parameters, transaction, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                    return rowAffects;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                this._mySqlConnection.Dispose();
            }
        }

        /// <summary>
        /// Cập nhật đối tượng 
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <param name="entity">Thông tin cập nhật</param>
        /// <returns>Trả về 1 nếu cập nhật thành công || trả về 0 nếu cập nhật thất bại</returns>
        public virtual int Update(Guid id, T entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                string nameProc = $"Proc_Update{_nameTable}ById";
                foreach (PropertyInfo prop in entity.GetType().GetProperties())
                {
                    var value = prop.GetValue(entity) == "" ? null : prop.GetValue(entity);
                    parameters.Add($"@_{prop.Name}", value);
                }
                parameters.Add($"@_{_nameTable}Id", id.ToString());
                this._mySqlConnection.Open();
                using (var transaction = this._mySqlConnection.BeginTransaction())
                {
                    int result = this._mySqlConnection.Execute(nameProc, param: parameters, transaction, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                this._mySqlConnection.Dispose();
            }
        }

        /// <summary>
        /// Xóa đối tượng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Trả về 1 nếu thực hiện thành công || trả về 0 nếu thực hiện thất bại</returns>
        public virtual int Delete(Guid id)
        {
            try
            {
                string nameProc = $"Proc_Delete{_nameTable}ById";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"_{_nameTable}Id", id.ToString());
                int result = this._mySqlConnection.Execute(nameProc, CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                this._mySqlConnection.Dispose();
            }
        }

        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <returns>Trả về danh sách đối tượng</returns>
        public virtual List<T> GetAll()
        {
            string nameProc = $"Proc_Get{this._nameTable}s";
            List<T> result = this._mySqlConnection.Query<T>(nameProc, commandType: CommandType.StoredProcedure).ToList();
            this._mySqlConnection.Dispose();
            return result;
        }

        /// <summary>
        /// Lấy một đối tượng theo id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>Trả về đối tượng || null nếu không tìm được</returns>
        public virtual T GetById(Guid id)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add($"@_{_nameTable}Id", id.ToString());
            string nameProc = $"Proc_Get{_nameTable}ById";
            var result = this._mySqlConnection.QueryFirstOrDefault<T>(nameProc, param: parameter, commandType: CommandType.StoredProcedure);
            this._mySqlConnection.Dispose();
            return result;
        }

        #endregion
    }
}
