using System;

namespace Entities
{
    /// <summary>
    /// گزارش تغییر وضعیت سفارش
    /// </summary>
    public class OrderStatusLog : BaseEntity<long>
    {

        /// <summary>
        /// سفارش
        /// </summary>
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        /// <summary>
        /// تاریخ تغییر
        /// </summary>
        public DateTime DateChange { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
