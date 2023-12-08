using MediatR;

namespace SeventhServers.Installers
{
    public static class MediatrInstaller
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(MediatrInstaller).Assembly);
            });

            return services;
        }
    }
}
