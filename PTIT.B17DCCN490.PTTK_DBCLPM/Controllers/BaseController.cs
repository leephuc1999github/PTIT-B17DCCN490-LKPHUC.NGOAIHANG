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
            List<T> entities = this._baseDAO.GetAll();
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
            T entity = this._baseDAO.GetById(id);
            return View("Edit", entity);
        }

        /// <summary>
        /// Giao diện thêm mới 
        /// </summary>
        /// <returns>Trả về giao diện thêm mới</returns>
        [HttpGet("Add")]
        public virtual IActionResult Add()
        {
            return View("Add");
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            int execute = this._baseDAO.Delete(id);
            ToastMessage message = new ToastMessage();
            if (execute == 0)
            {
                message.Type = TypeToast.info;
                message.Content = "Thực hiện không thành công!";
                TempData["UserMessage"] = JsonConvert.SerializeObject(message);
            }
            else
            {
                message.Type = TypeToast.success;
                message.Content = "Thực hiện thành công!";
                TempData["UserMessage"] = JsonConvert.SerializeObject(message);
            }
            return RedirectToAction("", typeof(T).Name);
            
        }
        #endregion
    }
}
