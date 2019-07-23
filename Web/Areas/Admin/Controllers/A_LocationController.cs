using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading;
using System.Threading.Tasks;
using WebFramework.Api;
using WebFramework.Filters;

namespace Web.Areas.Admin.Controllers
{
    /// <summary>
    ///  ادمین : استان و شهرها
    /// </summary>
    [Area("Admin")]
    [Route("api/[area]/[controller]/[action]")]
    [ApiController]
    [ApiResultFilter]
    [AllowAnonymous]
    public class A_LocationController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        private readonly ICityService _cityService;

        /// <summary>
        /// 
        /// </summary>
        public A_LocationController(IProvinceService provinceService,ICityService cityService)
        {
            _provinceService = provinceService;
            this._cityService = cityService;
        }

        /// <summary>
        /// افزودن استان
        /// </summary>
        /// <param name="province"></param>
        /// <param name="cancellationToken"></param>
        /// <returns name="apiresult"> خروجی</returns>
        [HttpPost]
        public async Task<ApiResult> AddProvince(ProvinceCreateDto province, CancellationToken cancellationToken)
        {
            var result = await _provinceService.AddAsync(province, cancellationToken);
            if (result == BaseResultStatus.Exists)
                return BadRequest("استان از قبل موجود است");

            if (result == BaseResultStatus.Ok)
                return Ok();

            return BadRequest("متاسفانه مشکلی پیش آمده است");
        }


        /// <summary>
        /// حذف یک استان
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> DeleteProvince(int provinceId, CancellationToken cancellationToken)
        {
            var res = await _provinceService.DeleteAsync(provinceId, cancellationToken);
            if (res == BaseResultStatus.NotExists)
                return BadRequest("استان مورد نظر یافت نشد");

            return Ok();
        }


        /// <summary>
        /// افزودن شهر
        /// </summary>
        /// <param name="city"></param>
        /// <param name="cancellationToken"></param>
        /// <returns name="apiresult"> خروجی</returns>
        [HttpPost]
        public async Task<ApiResult> AddCities(CityCreateDto city, CancellationToken cancellationToken)
        {
            var result = await _cityService.AddAsync(city, cancellationToken);
            if (result == BaseResultStatus.Exists)
                return BadRequest("شهر از قبل موجود است");

            if (result == BaseResultStatus.NotExists)
                return BadRequest("استان مورد نظر یافت نشد");

            if (result == BaseResultStatus.Ok)
                return Ok();

            return BadRequest("متاسفانه مشکلی پیش آمده است");
        }


        /// <summary>
        /// حذف یک شهر
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult> DeleteCity(int cityId, CancellationToken cancellationToken)
        {
            var res = await _provinceService.DeleteAsync(cityId, cancellationToken);
            if (res == BaseResultStatus.NotExists)
                return BadRequest("شهر مورد نظر یافت نشد");

            return Ok();
        }
    }
}
