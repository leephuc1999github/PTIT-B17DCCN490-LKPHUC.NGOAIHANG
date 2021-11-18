using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ENUM;
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Controllers
{
    [Route("[controller]")]
    public class BaseController<T> : Controller where T : class
    {
        #region Declare
        protected readonly IBaseDAO<T> _baseDAO;
        private readonly string _nameEntity;
        private ToastMessage message;
        #endregion

        #region Constructor
        public BaseController()
        {
            this._baseDAO = new BaseDAO<T>();
            this._nameEntity = typeof(T).Name;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Giao diện danh sách
        /// </summary>
        /// <returns>Trả về giao diện danh sách</returns>
        [HttpGet]
        public virtual IActionResult Index()
        {
            // lấy danh sách đối tượng
            List<T> entities = this._baseDAO.GetAll();
            // trả về giao diện chính
            return View("Index", entities);
        }

        /// <summary>
        /// Giao diện sửa đối tượng
        /// </summary>
        /// <param name="id">Id đối tượng</param>
        /// <returns>Giao diện sửa</returns>
        [HttpGet("Edit/{id}")]
        public virtual IActionResult Edit(Guid id)
        {
            // lấy đối tượng theo id
            T entity = this._baseDAO.GetById(id);
            // chuyển giao diện chỉnh sửa
            return View("Edit", entity);
        }

        /// <summary>
        /// Giao diện thêm mới 
        /// </summary>
        /// <returns>Trả về giao diện thêm mới</returns>
        [HttpGet("Add")]
        public virtual IActionResult Add()
        {
            // trả về giao diện thêm mới
            return View("Add");
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            // xóa
            int execute = this._baseDAO.Delete(id);
            return RedirectToAction("", typeof(T).Name);
            
        }
        #endregion
    }
}
