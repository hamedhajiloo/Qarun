using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// مشتریان
    /// </summary>
    public class Customer:BaseEntity<string>
    {
        [ForeignKey(nameof(Id))]
        public virtual User User { get; set; }


        /// <summary>
        /// طلب مشتری، در صورتی که خطای محاسبتی رخ داده باشد و مشتری هزینه بیشتری کرده باشد
        /// </summary>
        public int Claim { get; set; }


        /// <summary>
        /// سفارشات مشتری
        /// </summary>
        public virtual IList<CustomerOrder> CustomerOrders { get; set; }
    }
}
