using System;
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

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public OrderStatus OrderStatus { get; set; }


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
