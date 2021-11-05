using PTIT.B17DCCN490.PTTK_DBCLPM.Models.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.ViewModels
{
    public class ToastMessage
    {
        /// <summary>
        /// Kiểu thông báo
        /// </summary>
        public TypeToast Type { get; set; }


        /// <summary>
        /// Nội dung
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Tên đối tượng cảnh báo
        /// </summary>
        public string Name { get; set; }


    }
}
