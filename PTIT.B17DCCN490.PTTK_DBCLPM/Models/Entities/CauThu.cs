using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class CauThu
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
        /// Chiều cao
        /// </summary>
        public string ChieuCao { get; set; }
        
        /// <summary>
        /// Cân nặng
        /// </summary>
        public string CanNang { get; set; }
        
        /// <summary>
        /// Chân thuận
        /// </summary>
        public string ChanThuan { get; set; }

        /// <summary>
        /// Vị trí cầu thủ
        /// </summary>
        public ViTriCauThu ViTri { get; set; }


        /// <summary>
        /// Số áo
        /// </summary>
        public int SoAo { get; set; }
    }
}
