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
    internal class SoftwareVersionConfiguration : IEntityTypeConfiguration<SoftwareVersion>
    {
        public void Configure(EntityTypeBuilder<SoftwareVersion> builder)
        {
            builder.ToTable(nameof(SoftwareVersion));
            builder.HasKey(sv => new { sv.SoftwareId, sv.VersionId });
            builder.HasOne(sv => sv.Software).WithMany(s => s.SoftwareVersions).HasForeignKey(sv => sv.SoftwareId);
            builder.HasOne(sv => sv.Version).WithMany(v => v.SoftwareVersions).HasForeignKey(sv => sv.VersionId);
            builder.HasData(new SoftwareVersion { SoftwareId = 1, VersionId = 1, ReleaseDate = new DateTime(2017, 5, 12) }, new SoftwareVersion { SoftwareId = 1, VersionId = 3, ReleaseDate = new DateTime(2022, 8, 7) }, new SoftwareVersion { SoftwareId = 2, VersionId = 2, ReleaseDate = new DateTime(2019, 3, 10) });
        }
    }
}
