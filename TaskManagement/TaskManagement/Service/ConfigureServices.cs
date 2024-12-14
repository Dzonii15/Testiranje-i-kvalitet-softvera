using TaskManagement.Service.Implementations;

namespace TaskManagement.Service
{
    public static class ConfigureServices
    {

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }
    }
}
