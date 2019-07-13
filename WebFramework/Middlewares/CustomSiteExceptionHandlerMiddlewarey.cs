using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WebFramework.Middlewares
{
    public static class CustomSiteExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomSiteExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomSiteExceptionHandlerMiddleware>();
        }
    }

    public class CustomSiteExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<CustomSiteExceptionHandlerMiddleware> _logger;

        public CustomSiteExceptionHandlerMiddleware(RequestDelegate next,
            IHostingEnvironment env,
            ILogger<CustomSiteExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            ActionContext actionContext = new ActionContext
            {
                HttpContext = context
            };

            if (!context.Response.HasStarted)
            {
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    ViewResult view = new ViewResult
                    {
                        ViewName = "Error404"
                    };
                    await view.ExecuteResultAsync(actionContext);
                }
                if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    ViewResult view = new ViewResult
                    {
                        ViewName = "Error500"
                    };
                    await view.ExecuteResultAsync(actionContext);
                }
                if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    ViewResult view = new ViewResult
                    {
                        ViewName = "Error400"
                    };
                    await view.ExecuteResultAsync(actionContext);
                }
            }


            await _next(context);

        }
    }
}
