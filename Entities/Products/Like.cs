using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Like:IEntity
    {
        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }



        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }

    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(c => new { c.ProductId,c.UserId });
        }
    }
}
 