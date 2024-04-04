using Microsoft.Extensions.DependencyInjection;
using System;

namespace GYMGO.Desktop.Extensions
{
    public static class HttpCliensExtension
    {
        public static void ConfigureHttpCliens(this IServiceCollection services)
        {
            services.AddHttpClient("GYMGOApi", options =>
            {
                options.BaseAddress = new Uri("https://localhost:7090/");
            });
        }

    }
}