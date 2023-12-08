using Microsoft.EntityFrameworkCore;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Infrastructure.Repositories;

namespace SeventhServers.Infrastructure.Data
{
    public static class DataBaseSetup
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });

            services.AddScoped<IServerRepository, ServerRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            
            return services;
        }
    }
}
