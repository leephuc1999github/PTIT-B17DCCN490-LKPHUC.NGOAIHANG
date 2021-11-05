using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class TrongTai
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
        /// Năm sinh
        /// </summary>
        public int NamSinh { get; set; }
        
        /// <summary>
        /// Số năm kinh nghiệm
        /// </summary>
        public int SoNamKN { get; set; }
        
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string DiaChi { get; set; }
        
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string SDT { get; set; }
        
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
