using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Order : BaseEntity<long>
    {

        /// <summary>
        /// مشتری
        /// </summary>
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual User Customer { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// تاریخ سفارش
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// تاریخ بروزرسانی
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// روش پرداخت
        /// </summary>
        public OrderPaymentType OrderPaymentType { get; set; }

        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// جمع کل مبالغ بدون محاسبه مالیات و تخفیف
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// تخفیف کل
        /// </summary>
        public int TotalDiscount { get; set; }

        /// <summary>
        /// : قیمت نهایی کل - تخفیف + مالیات  
        /// </summary>
        public int Price { get; set; }


        /// <summary>
        /// به بانک هدایت شده یا خیر ؟
        /// </summary>
        public bool RedirectedToBank { get; set; }

        /// <summary>
        /// پرداخت موفق بوده ؟
        /// </summary>
        public bool? PaySucceeded { get; set; }


        /// <summary>
        /// سود قارون
        /// </summary>
        [ForeignKey(nameof(Income))]
        public long IncomeId { get; set; }
        public virtual Income Income { get; set; }


        public virtual IList<OrderChild> OrderChilds { get; set; }
        public virtual List<WalletLog> WalletLogs { get; set; }

    }
}
