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
    internal class ClientSoftwareVersionConfiguration : IEntityTypeConfiguration<ClientSoftwareVersion>
    {
        public void Configure(EntityTypeBuilder<ClientSoftwareVersion> builder)
        {
            builder.ToTable(nameof(ClientSoftwareVersion));
            builder.HasKey(cls => new { cls.ClientId, cls.SoftwareId, cls.VersionId });
            builder.HasOne(cls => cls.Client).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.ClientId);
            builder.HasOne(cls => cls.Software).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.SoftwareId);
            builder.HasOne(cls => cls.Version).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.VersionId);
            builder.HasData(new ClientSoftwareVersion { ClientId = 1, SoftwareId = 1, VersionId = 1 }, new ClientSoftwareVersion { ClientId = 1, SoftwareId = 2, VersionId = 2 }, new ClientSoftwareVersion { ClientId = 2, SoftwareId = 1, VersionId = 2 }, new ClientSoftwareVersion { ClientId = 4, SoftwareId = 3, VersionId = 2 });
        }
    }
}
