using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebFramework.Middlewares
{
    public class CustomMessage4DataAnnotationsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomMessage4DataAnnotationsMiddleware(RequestDelegate next, IHostingEnvironment env, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RequiredAttribute), typeof(CustomRequiredAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(StringLengthAttribute), typeof(CustomStringLengthAttributeAdapter));
            //DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(RangeAttribute), typeof(CustomRangeAttributeAdapter));

            await _next(context);
        }
    }
}