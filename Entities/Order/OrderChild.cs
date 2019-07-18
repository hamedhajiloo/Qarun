using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// سفارشات مشتری
    /// </summary>
    public class OrderChild:BaseEntity<long>
    {
       [ForeignKey(nameof(Id))]
        public virtual UserTransaction UserTransaction { get; set; }


        [ForeignKey(nameof(Order))]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }


        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }




        public OrderStatus OrderStatus { get; set; }


        public Reason4DisapprovedDelivery Reason4DisapprovedDelivery { get; set; }


        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        public DateTime? SendDate { get; set; }

        /// <summary>
        ///فروشنده 
        /// </summary>
        public string SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual User Seller { get; set; }

    }
}
