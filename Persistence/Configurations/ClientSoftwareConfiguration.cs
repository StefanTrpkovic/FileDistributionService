using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class ClientSoftwareConfiguration : IEntityTypeConfiguration<ClientSoftware>
    {
        public void Configure(EntityTypeBuilder<ClientSoftware> builder)
        {
            builder.ToTable(nameof(ClientSoftware));
            builder.HasKey(cls => new { cls.ClientId, cls.SoftwareId });
            builder.HasOne(cls => cls.Client).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.ClientId);
            builder.HasOne(cls => cls.Software).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.SoftwareId);
            builder.HasData(
                new ClientSoftware { ClientId = 1, SoftwareId = 1 }, 
                new ClientSoftware { ClientId = 1, SoftwareId = 2 }, 
                new ClientSoftware { ClientId = 2, SoftwareId = 1 }, 
                new ClientSoftware { ClientId = 4, SoftwareId = 3 }
            );
        }
    }
}
