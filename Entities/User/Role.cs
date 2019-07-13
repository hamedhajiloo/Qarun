using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Role : IdentityRole, IEntity
    {
        #region Properties

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        #endregion Properties
    }

    #region Config

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }

    #endregion Config
}