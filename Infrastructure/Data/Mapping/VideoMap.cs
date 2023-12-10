

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeventhServers.Domain.Models;

namespace SeventhServers.Infrastructure.Data.Mapping;

internal class VideoMap : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Description)
            .IsRequired();

        builder
            .Property(x => x.SizeInBytes)
            .IsRequired();

        builder 
            .Property(x => x.CreatedAt)
            .IsRequired();

        builder
            .HasOne(x => x.Server)
            .WithMany(x => x.Videos);

        builder
            .Ignore(x => x.File64);

        builder
            .ToTable("Video");
    }
}
