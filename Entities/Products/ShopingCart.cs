using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class ShopingCart:BaseEntity<long>
    {
        [Required]
        [Display(Name = "کاربر")]
        public string UserId { get; set; }
        public virtual User User { get; set; }


        [Display(Name = "محصول")]
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        public bool CancelPurchase { get; set; }
    }
    #region Config

    public class ShopingCartConfiguration : IEntityTypeConfiguration<ShopingCart>
    {
        public void Configure(EntityTypeBuilder<ShopingCart> builder)
        {
            builder.HasIndex(p => new { p.UserId, p.ProductId }).IsUnique().HasName("Group1");
        }
    }

    #endregion Config
}
