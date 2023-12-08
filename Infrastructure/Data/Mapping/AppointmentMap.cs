

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeventhServers.Domain.Models;

namespace SeventhServers.Infrastructure.Data.Mapping;

internal class ServerMap : IEntityTypeConfiguration<Server>
{
    public void Configure(EntityTypeBuilder<Server> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
           .Property(x => x.CreatedAt)
           .IsRequired();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
           .Property(x => x.Ip)
           .IsRequired();

        builder
            .Property(x => x.Port)
            .IsRequired();
       

        builder
            .ToTable("Server");
    }
}
