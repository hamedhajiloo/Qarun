using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Category:BaseEntity
    {
        public string Titel { get; set; }



        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual Category Parent { get; set; }


        public ICollection<Category> Categories { get; set; }


        public string Picture { get; set; }


        public virtual ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
