using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// فروشنده های سفارش
    /// </summary>
    public class OrderSeller:BaseEntity<long>
    {

        /// <summary>
        /// سفارش
        /// </summary>
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }


        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        public DateTime? SendDate { get; set; }

        /// <summary>
        ///فروشنده 
        /// </summary>
        public string SellerId { get; set; }
        [ForeignKey(nameof(SellerId))]
        public virtual Seller Seller { get; set; }

        public virtual List<OrderShopDetails> OrderShopDetails { get; set; }

    }


}
