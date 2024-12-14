using TaskManagement.Repository.Implementations;

namespace TaskManagement.Repository
{
    public static class ConfigureServices
    {

        public static IServiceCollection RegisterRegistries(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            return services;
        }
    }
}
