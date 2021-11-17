using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class TrongTai : TTNguoi
    {
        /// <summary>
        /// Năm sinh
        /// </summary>
        public int NamSinh { get; set; }
        
        /// <summary>
        /// Số năm kinh nghiệm
        /// </summary>
        public int SoNamKN { get; set; }

        /// <summary>
        /// Lương trọng tài
        /// </summary>
        public float LuongTran { get; set; }
    }
}
