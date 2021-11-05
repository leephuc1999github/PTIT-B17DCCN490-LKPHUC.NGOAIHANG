using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class BXHCauThuBanThang : CauThu
    {
        public int KienTao { get; set; }
        public int BanThang { get; set; }
        public int ThuHang { get; set; }
        public int ThoiGian { get; set; }
    }
}
