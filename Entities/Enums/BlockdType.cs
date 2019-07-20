using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// رأی
    /// </summary>
    public enum BlockeType
    {
        /// <summary>
        /// مسدود نیست
        /// </summary>
        [Display(Name ="مسدود نیست")]
        Not=0,

        /// <summary>
        /// تعلیق بابت بدهی تا زمان تسویه حساب
        /// </summary>
        [Display(Name = "تعلیق بابت بدهی تا زمان تسویه حساب")]
        Debt =1,

        /// <summary>
        /// سه روز تعلیق
        /// </summary>
        [Display(Name = "سه روز تعلیق")]
        D3 =2,

        /// <summary>
        /// یک هفته تعلیق
        /// </summary>
        [Display(Name = "یک هفته تعلیق")]
        W1 =3,


        /// <summary>
        /// یک ماه تعلیق
        /// </summary>
        [Display(Name = "یک ماه تعلیق")]
        M1 =4
    }
}
