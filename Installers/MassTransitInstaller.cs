using MassTransit;
using Microsoft.EntityFrameworkCore;
using SeventhServers.Domain.Abstractions.FileManagement;
using SeventhServers.Domain.Abstractions.Repositories;
using SeventhServers.Domain.ConsumerObjects.Video;
using SeventhServers.Infrastructure.Data;
using SeventhServers.Infrastructure.FileManagement;
using SeventhServers.Infrastructure.Repositories;
using SeventhVideos.Domain.UseCases.Videos.Recycler;
using System;

namespace SeventhServers.Installers
{
    public static class MassTransitInstaller
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, string RabbitMqConnection)
        {
            services.AddMassTransit(bus =>
            {
                bus.UsingRabbitMq((context, busConfigurator) =>
                {
                    busConfigurator.Host(RabbitMqConnection);
                    busConfigurator.ConfigureEndpoints(context);

                });

                bus.AddConsumer<VideoRecyclerConsumer>().Endpoint(e =>
                {
                    if (e is IRabbitMqReceiveEndpointConfigurator r)
                    {
                        r.Durable = false;
                        r.AutoStart = true;
                        r.PrefetchCount = 1;
                    }
                });


            });

            return services;
        }
    }
}
