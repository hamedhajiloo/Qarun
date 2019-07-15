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
        /// پرداخت آنلاین
        /// </summary>
        [Display(Name = "پرداخت آنلاین")]
        Online = 1,

        /// <summary>
        /// کیف پول
        /// </summary>
        [Display(Name = "پرداخت با کیف پول")]
        WalletCharge = 2,

        /// <summary>
        /// کیف پول
        /// </summary>
        [Display(Name = "پرداخت نقدی")]
        Cash = 3
    }
}
