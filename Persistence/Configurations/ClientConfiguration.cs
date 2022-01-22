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
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(nameof(Client));
            builder.HasOne(cl => cl.Country).WithMany(c => c.Clients).HasForeignKey(cl => cl.CountryId);
            builder.HasOne(cl => cl.Channel).WithMany(c => c.Clients).HasForeignKey(cl => cl.ChannelId);
            builder.HasData(
                new Client { Id = 1, Name = "Stefan", Surname = "Trpkovic", CountryId = 1, ChannelId = 3, Email = "stefan.trpkovic@gmail.com" }, 
                new Client { Id = 2, Name = "Anders", Surname = "Hansen", CountryId = 3, ChannelId = 2, Email = "anders.hansen@gmail.com" }, 
                new Client { Id = 3, Name = "Fabricio", Surname = "Bianchi", CountryId = 2, ChannelId = 1, Email = "fabricio.bianchi@gmail.com" }, 
                new Client { Id = 4, Name = "Andy", Surname = "Smith", CountryId = 4, ChannelId = 1, Email = "andy.smith@gmail.com" }, 
                new Client { Id = 5, Name = "Jan", Surname = "Vrba", CountryId = 6, ChannelId = 2, Email = "jan.vrba@gmail.com" }, 
                new Client { Id = 6, Name = "Alexander", Surname = "Sidorov", CountryId = 5, ChannelId = 2, Email = "alex.sidorov@gmail.com" }
            );
        }
    }
}
