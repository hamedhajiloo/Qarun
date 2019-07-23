using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Filters;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    ///  ادمین : استان و شهرها
    /// </summary>
    [Area("Common")]
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [ApiResultFilter]
    [AllowAnonymous]
    public class C_LocationController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly ICityService _cityService;

        /// <summary>
        /// 
        /// </summary>
        public C_LocationController(IProvinceService provinceService, ICityService cityService)
        {
            _provinceService = provinceService;
            _cityService = cityService;
        }

        /// <summary>
        /// لیست استان ها
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>ورودی ندارد</returns>
        [HttpGet]
        public async Task<ApiResult<List<ProvinceSelectDto>>> GetAllProvince(CancellationToken cancellationToken)
        {
            return Ok(await _provinceService.GetAllAsync(cancellationToken));
        }


        /// <summary>
        /// لیست شهر ها
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="cancellationToken"></param>
        [HttpGet]
        public async Task<ApiResult<List<CitySelectDto>>> GetAllCities (int provinceId,CancellationToken cancellationToken)
        {
            return Ok(await _cityService.GetAllAsync(provinceId,cancellationToken));
        }
    }
}
