using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal class SoftwareChannelConfiguration : IEntityTypeConfiguration<SoftwareChannel>
    {
        public void Configure(EntityTypeBuilder<SoftwareChannel> builder)
        {
            builder.ToTable(nameof(SoftwareChannel));
            builder.HasKey(sc => new { sc.SoftwareId, sc.ChannelId });
            builder.HasOne(sc => sc.Software).WithMany(s => s.SoftwareChannels).HasForeignKey(sc => sc.SoftwareId);
            builder.HasOne(sc => sc.Channel).WithMany(c => c.SoftwareChannels).HasForeignKey(sc => sc.ChannelId);
            builder.HasData(new SoftwareChannel { SoftwareId = 1, ChannelId = 1 }, new SoftwareChannel { SoftwareId = 1, ChannelId = 3 }, new SoftwareChannel { SoftwareId = 2, ChannelId = 2 });
        }
    }
}
