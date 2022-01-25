using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class SoftwareConfiguration : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            builder.ToTable(nameof(Software));
            builder.HasOne(cl => cl.Channel).WithMany(c => c.Softwares).HasForeignKey(cl => cl.ChannelId);
            builder.HasData(
                new Software { Id = 1, Name = "Visual Studio", PackageId = "A0B4NCJ6", ChannelId = 1, Version = 1, ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0) }, 
                new Software { Id = 2, Name = "Visual Studio Code", PackageId = "K65FB9D4", ChannelId = 2, Version = 2, ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0)}, 
                new Software { Id = 3, Name = "Mongo DB Compass", PackageId = "P2F86NTC", ChannelId = 3, Version = 3, ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0) }, 
                new Software { Id = 4, Name = "Visual Studio", PackageId = "FN51MQ6G", ChannelId = 2, Version = 2, ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0)}, 
                new Software { Id = 5, Name = "Ditto pasting tool", PackageId = "MY49C6KL", ChannelId = 1, Version = 1, ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0)}
            );
        }
    }
}
