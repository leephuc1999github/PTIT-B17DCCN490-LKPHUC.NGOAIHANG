using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models
{
    public interface IBaseDAO<T> : IDisposable
    {

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <returns>Trả về 1 nếu thực hiện thành công || trả về 0 nếu thực hiện thất bại</returns>
        public int Insert(T entity);

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <returns>Trả về 1 nếu cập nhật thành công || trả về 0 nếu cập nhật thất bại</returns>
        public int Update(Guid id, T entity);

        /// <summary>
        /// Xóa đối tượng theo id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>Trả về 1 nếu cập nhật thành công || trả về 0 nếu cập nhật thất bại</returns>
        public int Delete(Guid id);

        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <returns>Trả về danh sách đối tượng</returns>
        public List<T> GetAll();

        /// <summary>
        /// Lấy một đối tượng theo id
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>Trả về đối tượng || null nếu không tìm thấy</returns>
        public T GetById(Guid id);
    }
}
