using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class TTNguoi
    {
        /// <summary>
        /// Id 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Tên  
        /// </summary>
        public string Ten { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string DiaChi { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// SDT
        /// </summary>
        public string SDT { get; set; }
    }
}
