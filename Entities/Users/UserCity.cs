using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class UserCity:IEntity
    {
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }



        public int CitytId { get; set; }
        [ForeignKey(nameof(CitytId))]
        public virtual City City { get; set; }

    }

    public class UserCityConfiguration : IEntityTypeConfiguration<UserCity>
    {
        public void Configure(EntityTypeBuilder<UserCity> builder)
        {
            builder.HasKey(c => new { c.UserId, c.CitytId });
        }
    }
}
