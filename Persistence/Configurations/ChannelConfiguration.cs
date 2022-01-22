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
    internal class ChannelConfiguration : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.ToTable(nameof(Channel));
            builder.HasData(
                new Channel { Id = 1, Name = "Public" }, 
                new Channel { Id = 2, Name = "Internal Beta" }, 
                new Channel { Id = 3, Name = "Insider" }
            );
        }
    }
}