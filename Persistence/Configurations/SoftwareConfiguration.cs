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
                new Software { Id = 1, Name = "Visual Studio", PackageVersion = Guid.NewGuid(), ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0) , 
                    Version = 1, ChannelId = 1 }, 
                new Software { Id = 2, Name = "Visual Studio Code", PackageVersion = Guid.NewGuid(), ReleaseDate = new DateTime(2021, 5, 12, 0, 0, 0, 0), 
                    Version = 1, ChannelId = 2 }, 
                new Software { Id = 3, Name = "Visual Studio", PackageVersion = Guid.NewGuid(), ReleaseDate = new DateTime(2021, 8, 20, 0, 0, 0, 0), 
                    Version = 2, ChannelId = 3 }, 
                new Software { Id = 4, Name = "Visual Studio", PackageVersion = Guid.NewGuid(), ReleaseDate = new DateTime(2017, 5, 12, 0, 0, 0, 0), 
                    Version = 3, ChannelId = 2 }, 
                new Software { Id = 5, Name = "Visual Studio Code", PackageVersion = Guid.NewGuid(), ReleaseDate = new DateTime(2022, 5, 12, 0, 0, 0, 0), 
                    Version = 2, ChannelId = 1 }
            );
        }
    }
}
