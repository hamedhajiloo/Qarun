using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// سفارشات مشتری
    /// </summary>
    public class CustomerOrder:BaseEntity<long>
    {
       [ForeignKey(nameof(Id))]
        public virtual UserTransaction UserTransaction { get; set; }

        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
