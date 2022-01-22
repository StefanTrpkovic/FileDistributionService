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
    internal class SoftwareConfiguration : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            builder.ToTable(nameof(Software));
            builder.HasOne(cl => cl.SoftwareType).WithMany(c => c.Softwares).HasForeignKey(cl => cl.SoftwareTypeId);
            builder.HasData(new Software { Id = 1, Name = "Visual Studio", SoftwareTypeId = 1, PackageVersion = Guid.NewGuid() }, new Software { Id = 2, Name = "Visual Studio Code", SoftwareTypeId = 2, PackageVersion = Guid.NewGuid() }, new Software { Id = 3, Name = "Kaspersky", SoftwareTypeId = 3, PackageVersion = Guid.NewGuid() }, new Software { Id = 4, Name = "Avast Antivirus", SoftwareTypeId = 1, PackageVersion = Guid.NewGuid() }, new Software { Id = 5, Name = "Azure CLI", SoftwareTypeId = 3, PackageVersion = Guid.NewGuid() });
        }
    }
}
