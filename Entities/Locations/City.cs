using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// شهرها
    /// </summary>
    public class City:BaseEntity
    {
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Title { get; set; }


        /// <summary>
        /// استان
        /// </summary>
        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} را انتخاب نمایید")]
        [ForeignKey(nameof(Province))]
        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

    }
}
