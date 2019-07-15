using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// نام خریدار
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی خریدار
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// تلفن ضروری
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string Mobile { get; set; }

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
        /// : قیمت نهایی کل - تخفیف + مالیات + هزینه ارسال  
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// آدرس کاربر
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// کد پستی کاربر
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// آیپی کاربر
        /// </summary>
        public string UserIPAddress { get; set; }

        /// <summary>
        /// حذف شده
        /// </summary>
        public bool Deleted { get; set; }

        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// هزینه کل ارسال
        /// </summary>
        public int TotalShippingCost { get; set; }


        /// <summary>
        /// کد منحصر به فرد پس از پرداخت
        /// </summary>
        public long? UniqueCode { get; set; }

        /// <summary>
        /// به بانک هدایت شده یا خیر ؟
        /// </summary>
        public bool RedirectedToBank { get; set; }

        /// <summary>
        /// پرداخت موفق بوده ؟
        /// </summary>
        public bool? PaySucceeded { get; set; }
        public int InCityShippingCost { get; set; }


        public virtual IList<OrderSeller> OrderSellers { get; set; }
        public virtual IList<CustomerOrder> CustomerOrders { get; set; }
        public virtual IList<OrderStatusLog> OrderStatusLogs { get; set; }
        public virtual List<WalletLog> WalletLogs { get; set; }



    }
}
