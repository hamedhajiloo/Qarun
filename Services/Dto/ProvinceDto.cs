using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services
{
    public class ProvinceCreateDto:BaseDto<ProvinceCreateDto, Province,int>
    {
        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Title { get; set; }
    }

    public class ProvinceSelectDto : BaseDto<ProvinceSelectDto, Province, int>
    {
        [Display(Name = "استان")]
        [Required(ErrorMessage = "{0} را وارد نمایید")]
        public string Title { get; set; }
    }
}
