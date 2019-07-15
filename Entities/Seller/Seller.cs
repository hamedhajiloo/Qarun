using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Seller : BaseEntity<string>
    {
        [ForeignKey(nameof(Id))]
        public virtual User User { get; set; }

        public OrderLimitation OrderLimitation { get; set; }

        public virtual IList<OrderSeller> OrderSellers { get; set; }

    }
}
