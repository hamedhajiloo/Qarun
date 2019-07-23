using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// استان‌ها
    /// </summary>
    public class Province:BaseEntity
    {
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Title { get; set; }


        /// <summary>
        /// شهرها
        /// </summary>
        public virtual IList<City> Cities { get; set; }
    }
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasMany(c => c.Cities).WithOne(c => c.Province).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
