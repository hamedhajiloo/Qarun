using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum OrderPaymentType
    {
        /// <summary>
        /// تنظیم نشده
        /// </summary>
        [Display(Name = "تنظیم نشده")]
        NotSet = 0,

        /// <summary>
        ///پرداخت آنلاین از درگاه
        /// </summary>
        [Display(Name = "پرداخت آنلاین از درگاه")]
        OnlineBankPort = 1,

        /// <summary>
        /// پرداخت انلاین پس از تحویل
        /// کیف پول
        /// </summary>
        [Display(Name = "پرداخت انلاین پس از تحویل")]
        OnlineDelivery = 2,

        /// <summary>
        /// پرداخت نقدی
        /// </summary>
        [Display(Name = "پرداخت نقدی")]
        Cash = 3
    }
}
