using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// تراکنش های کاربر
    /// </summary>
    [Table("User_Transactions")]
    public class UserTransaction : BaseEntity<long>
    {

        /// <summary>
        /// مبلغ
        /// </summary>
        [Display(Name = "مبلغ")]
        public long Price { get; set; }


        /// <summary>
        /// تاریخ درج
        /// </summary>
        public DateTime InsertDate { get; set; }

        /// <summary>
        /// کد رزرو
        /// </summary>
        public string ReservationCode { get; set; }

        /// <summary>
        /// رسید دیجیتالی
        /// </summary>
        [Display(Name = "رسید دیجیتالی")]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// وضعیت پرداختی
        /// </summary>
        public PaymentState PaymentState { get; set; }

        /// <summary>
        /// وضعیت پرداختی به صورت رشته
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime? PaidDate { get; set; }


        /// <summary>
        /// نوع درخواست کاربر
        /// </summary>
        public UserTransactionType Type { get; set; }


        /// <summary>
        /// نوع پرداخت
        /// </summary>
        public PaymentType PaymentType { get; set; }

        /// <summary>
        /// کد رهگیری
        /// </summary>
        [Display(Name = "کد رهگیری")]
        public string TRACENO { get; set; }

        public string RRN { get; set; }

        public string CID { get; set; }

        [Display(Name = "شماره کارت")]
        public string SecurePan { get; set; }

        /// <summary>
        /// کاربر
        /// </summary>
        public string UserId { get; set; }
        public virtual User User { get; set; }


        [ForeignKey(nameof(CustomerOrder))]
        public long CustomerOrderId { get; set; }
        public virtual OrderChild CustomerOrder { get; set; }


        public virtual List<WalletLog> WalletLogs { get; set; }

    }
}
