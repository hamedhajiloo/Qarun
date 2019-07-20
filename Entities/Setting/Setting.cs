using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Setting : BaseEntity
    {
        /// <summary>
        /// تعداد ریپورت ها برای بلاک کردن یوزر
        /// </summary>
        public int UserCount4Report { get; set; }

    }
}