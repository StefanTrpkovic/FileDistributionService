using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = Domain.Entities.Version;

namespace Persistence.Configurations
{
    internal class VersionConfiguration : IEntityTypeConfiguration<Version>
    {
        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable(nameof(Version));
            builder.HasData(new Version { Id = 1, VersionCode = 3 }, new Version { Id = 2, VersionCode = 2 }, new Version { Id = 3, VersionCode = 1 });
        }
    }
}
