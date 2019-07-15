using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// گزارشات کیف پول
    /// </summary>
    public class WalletLog:BaseEntity<long>
    {

        /// <summary>
        /// مبلغ
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// نوع عملیات
        /// </summary>
        public ChargeOperation ChargeOperation { get; set; }

        /// <summary>
        /// نوع شارژ
        /// </summary>
        public ChargeType ChargeType { get; set; }

        /// <summary>
        /// کاربر
        /// </summary>
        public string UserId { get; set; }
        public virtual User User { get; set; }

       
        /// <summary>
        /// سفارش
        /// </summary>
        public long? OrderId { get; set; }
        public virtual Order Order { get; set; }

        /// <summary>
        /// تراکنش کاربر
        /// </summary>
        public long? UserTransactionId { get; set; }
        public virtual UserTransaction UserTransaction { get; set; }
    }
}
