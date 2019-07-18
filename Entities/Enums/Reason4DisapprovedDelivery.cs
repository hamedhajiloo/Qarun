using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public enum Reason4DisapprovedDelivery
    {
        [Display(Name = "مشخص نشده")]
        None = 0,


        [Display(Name = "کالایی تحویل نگرفته ام")]
        IHaveNotDeliveredAnything = 1,


        [Display(Name = "کالای تحویل شده معیوب است")]
        DeliveredProductsAreDefective = 2,


        [Display(Name = "کالا با تصویر سفارش شده مغایرت دارد")]
        ProductIsInConflictWithTheImage = 3
    }
}
