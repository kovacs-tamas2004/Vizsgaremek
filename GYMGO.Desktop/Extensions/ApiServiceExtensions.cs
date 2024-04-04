using GYMGO.HttpService.Service;
using GYMGO.Shared.Assamblers;
using Microsoft.Extensions.DependencyInjection;

namespace GYMGO.Desktop.Extensions
{
    public static class ApiServiceExtensions
    {
        public static void ConfigureApiServices(this IServiceCollection services)
        {
            services.AddScoped<ITrainerService, TrainerService>();
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<TrainerAssambler>();
        }
    }
}