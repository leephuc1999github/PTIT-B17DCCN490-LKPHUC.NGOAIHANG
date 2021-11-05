using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Key : Attribute { }

        /// <summary>
        /// Trường không để trống
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Required : Attribute { }

        /// <summary>
        /// KIểm tra trùng
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Duplicate : Attribute { }

        /// <summary>
        /// Định dạng email
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class Email : Attribute { }

        /// <summary>
        /// Độ dài chuỗi và định dạng
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class LengthAndFormat : Attribute { }


        /// <summary>
        /// Not map
        /// </summary>
        [AttributeUsage(AttributeTargets.Property)]
        public class NotMapped : Attribute { }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src);
        }


    }
}
