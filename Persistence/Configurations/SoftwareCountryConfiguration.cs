using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    internal class SoftwareCountryConfiguration : IEntityTypeConfiguration<SoftwareCountry>
    {
        public void Configure(EntityTypeBuilder<SoftwareCountry> builder)
        {
            builder.ToTable(nameof(SoftwareCountry));
            builder.HasKey(sc => new { sc.SoftwareId, sc.CountryId });
            builder.HasOne(sc => sc.Software).WithMany(s => s.SoftwareCountries).HasForeignKey(sc => sc.SoftwareId);
            builder.HasOne(sc => sc.Country).WithMany(c => c.SoftwareCountries).HasForeignKey(sc => sc.CountryId);
            builder.HasData(
                new SoftwareCountry { SoftwareId = 1, CountryId = 1 }, 
                new SoftwareCountry { SoftwareId = 1, CountryId = 2 }, 
                new SoftwareCountry { SoftwareId = 1, CountryId = 4 }, 
                new SoftwareCountry { SoftwareId = 2, CountryId = 5 }, 
                new SoftwareCountry { SoftwareId = 2, CountryId = 6 }, 
                new SoftwareCountry { SoftwareId = 2, CountryId = 4 }, 
                new SoftwareCountry { SoftwareId = 3, CountryId = 5 }, 
                new SoftwareCountry { SoftwareId = 4, CountryId = 6 }, 
                new SoftwareCountry { SoftwareId = 4, CountryId = 4 });
        }
    }
}
