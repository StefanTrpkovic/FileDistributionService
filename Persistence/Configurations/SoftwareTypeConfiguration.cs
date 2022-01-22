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
    internal class SoftwareTypeConfiguration : IEntityTypeConfiguration<SoftwareType>
    {
        public void Configure(EntityTypeBuilder<SoftwareType> builder)
        {
            builder.ToTable(nameof(SoftwareType));
            builder.HasData(new SoftwareType { Id = 1, Name = "Firmware"}, new SoftwareType { Id = 2, Name = "PC Installation" }, new SoftwareType { Id = 3, Name = "Single File" });
        }
    }
}
