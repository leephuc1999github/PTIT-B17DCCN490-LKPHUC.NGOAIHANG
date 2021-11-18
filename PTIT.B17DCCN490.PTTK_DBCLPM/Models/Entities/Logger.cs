using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public static class Logger
    {
        private static string nameFile = "Log.txt";

        /// <summary>
        /// Ghi lịch sử 
        /// </summary>
        /// <param name="nameFunc">Tên chức năng</param>
        /// <param name="mess">Thông báo</param>
        public static void Write(string nameFunc, string mess)
        {
            try
            {
                if (!File.Exists(nameFile))
                {
                    using (FileStream fs = File.Create(nameFile)) { fs.Close(); }
                }
                using (StreamWriter sw = File.AppendText(nameFile))
                {
                    sw.WriteLine($"{DateTime.Now}\t{nameFunc}\t{mess}");
                    sw.Close();
                }
            }
            catch (Exception ex) {  }
            
        }
    }
}
