using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public enum OrderLimitation
    {
        /// <summary>
        /// بدون محدودیت
        /// </summary>
        [Display(Name = "بدون محدودیت")]
        Zero = 0,

        /// <summary>
        ///ده هزار تومان
        /// </summary>
        [Display(Name = "ده هزار تومان")]
        One = 1,

        /// <summary>
        /// بیست هزار تومان
        /// </summary>
        [Display(Name = "بیست هزار تومان")]
        Two = 2,

        /// <summary>
        /// سی هزار تومان
        /// </summary>
        [Display(Name = "سی هزار تومان")]
        Three = 3,

        /// <summary>
        /// چهل هزار تومان
        /// </summary>
        [Display(Name = "چهل هزار تومان")]
        Four = 4,

        /// <summary>
        /// پنجاه هزار تومان
        /// </summary>
        [Display(Name = "پنجاه هزار تومان")]
        Five = 5,

        /// <summary>
        ///صد هزار تومان
        /// </summary>
        [Display(Name = "صد هزار تومان")]
        Ten = 6

    }
}
