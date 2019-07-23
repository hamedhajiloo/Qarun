using Entities;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class CityCreateDto : BaseDto<CityCreateDto, City, int>
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
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public int ProvinceId { get; set; }


    }

    public class CitySelectDto : BaseDto<CitySelectDto, City, int>
    {
        /// <summary>
        /// عنوان
        /// </summary>
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Title { get; set; }
    }
}
