using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Following : BaseEntity<string>
    {
        [Key,ForeignKey(nameof(Id))]
        public virtual User User { get; set; }
    }
}
