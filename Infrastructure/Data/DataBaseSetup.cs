using Microsoft.EntityFrameworkCore;

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
            
            return services;
        }
    }
}
