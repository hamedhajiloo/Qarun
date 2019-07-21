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
}
