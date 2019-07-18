using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class ProductHashtag:IEntity
    {

        public long HashtagId { get; set; }
        [ForeignKey(nameof(HashtagId))]
        public virtual Hashtag Hashtag { get; set; }



        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

    }

    public class ProductHashtagConfiguration : IEntityTypeConfiguration<ProductHashtag>
    {
        public void Configure(EntityTypeBuilder<ProductHashtag> builder)
        {
            builder.HasKey(c => new { c.HashtagId, c.ProductId });
        }
    }
}
