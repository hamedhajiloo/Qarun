using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Income:BaseEntity<long>
    {
        [ForeignKey(nameof(Order))]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        /// <summary>
        /// در صد
        /// </summary>
        public int Percentage { get; set; }


        public decimal SaleAmount { get; set; }


        public decimal Amount { get; set; }


    }
}
