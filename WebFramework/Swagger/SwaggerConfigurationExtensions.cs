using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebFramework.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                   name: "QarunApiDocs",
                   info: new Microsoft.OpenApi.Models.OpenApiInfo()
                   {
                       Title = "Qarun API",
                       Version = "1",
                       Description = "Through this API you can access Qarun Api.",
                       Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                       {
                           Email = "info@qarun.ir",
                           Name = "Qarun",
                           Url = new Uri("http://qarun.ir")
                       },
                       License = new Microsoft.OpenApi.Models.OpenApiLicense()
                       {
                           Name = "MIT License",
                           Url = new Uri("https://opensource.org/licenses/MIT")
                       }
                   });
            });
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            //Assert.NotNull(app, nameof(app));

            //Swagger middleware for generate "Open API Documentation" in swagger.json
            app.UseSwagger();

            ////Swagger middleware for generate UI from swagger.json
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/QarunApiDocs/swagger.json",
                    "Qarun API");
            });

        }
    }
}
