using GYMGO.Backend.Context;
using GYMGO.Backend.ContextRepos;
using GYMGO.Shared.Assamblers;
using GYMGO.Backend.Repos;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Extensions
{
    public static class GymgoBackendExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            services.AddCors(option =>
                 option.AddPolicy(name: "GYMCors",
                     policy =>
                     {
                         policy.WithOrigins("https://localhost:7090/")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                     }
                 )
            );
        }

        public static void ConfigureInMemoryContext(this IServiceCollection services)
        {
            string dbName = "GYMGO" + Guid.NewGuid();
            services.AddDbContextFactory<GymgoContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
            services.AddDbContextFactory<GymgoInMemoryContext>(
                options => options.UseInMemoryDatabase(databaseName: dbName)
                );
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            services.AddScoped<ITrainerRepo, TrainerInMemoryRepo>();
            services.AddScoped<IVisitorRepo, VisitorInMemoryRepo>();
            services.AddScoped<IOwnerRepo, OwnerInMemoryRepo>();
        }

        public static void ConfigureAssamblers(this IServiceCollection services)
        {
            services.AddScoped<TrainerAssambler>();
            services.AddScoped<VisitorAssambler>();
            services.AddScoped<OwnerAssambler>();
        }
    }
}
