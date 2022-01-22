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
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));
            builder.HasData(new Country { Id = 1, Name = "Macedonia" }, new Country { Id = 2, Name = "Italy" }, new Country { Id = 3, Name = "Denmark" }, new Country { Id = 4, Name = "USA" }, new Country { Id = 5, Name = "Russia" }, new Country { Id = 6, Name = "Czech Republic" });
        }
    }
}
