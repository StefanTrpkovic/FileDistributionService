﻿using FileDistributionService.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Version = FileDistributionService.Entity.Version;

namespace FileDistributionService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasOne(cl => cl.Country).WithMany(c => c.Clients).HasForeignKey(cl => cl.CountryId);
            modelBuilder.Entity<Client>().HasOne(cl => cl.Channel).WithMany(c => c.Clients).HasForeignKey(cl => cl.ChannelId);
            modelBuilder.Entity<Software>().HasOne(cl => cl.SoftwareType).WithMany(c => c.Softwares).HasForeignKey(cl => cl.SoftwareTypeId);
            modelBuilder.Entity<ClientSoftwareVersion>().HasKey(cls => new { cls.ClientId, cls.SoftwareId, cls.VersionId });
            modelBuilder.Entity<ClientSoftwareVersion>().HasOne(cls => cls.Client).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.ClientId);
            modelBuilder.Entity<ClientSoftwareVersion>().HasOne(cls => cls.Software).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.SoftwareId);
            modelBuilder.Entity<ClientSoftwareVersion>().HasOne(cls => cls.Version).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.VersionId);
            modelBuilder.Entity<SoftwareChannel>().HasKey(sc => new { sc.SoftwareId, sc.ChannelId });
            modelBuilder.Entity<SoftwareChannel>().HasOne(sc => sc.Software).WithMany(s => s.SoftwareChannels).HasForeignKey(sc => sc.SoftwareId);
            modelBuilder.Entity<SoftwareChannel>().HasOne(sc => sc.Channel).WithMany(c => c.SoftwareChannels).HasForeignKey(sc => sc.ChannelId);
            modelBuilder.Entity<SoftwareVersion>().HasKey(sv => new { sv.SoftwareId, sv.VersionId });
            modelBuilder.Entity<SoftwareVersion>().HasOne(sv => sv.Software).WithMany(s => s.SoftwareVersions).HasForeignKey(sv => sv.SoftwareId);
            modelBuilder.Entity<SoftwareVersion>().HasOne(sv => sv.Version).WithMany(v => v.SoftwareVersions).HasForeignKey(sv => sv.VersionId);
            modelBuilder.Entity<SoftwareCountry>().HasKey(sc => new { sc.SoftwareId, sc.CountryId });
            modelBuilder.Entity<SoftwareCountry>().HasOne(sc => sc.Software).WithMany(s => s.SoftwareCountries).HasForeignKey(sc => sc.SoftwareId);
            modelBuilder.Entity<SoftwareCountry>().HasOne(sc => sc.Country).WithMany(c => c.SoftwareCountries).HasForeignKey(sc => sc.CountryId);

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Macedonia" }, new Country { Id = 2, Name = "Italy" }, new Country { Id = 3, Name = "Denmark" }, new Country { Id = 4, Name = "USA" }, new Country { Id = 5, Name = "Russia" }, new Country { Id = 6, Name = "Czech Republic" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, Name = "Stefan", Surname = "Trpkovic", CountryId = 1, ChannelId = 3, Email = "stefan.trpkovic@gmail.com" }, new Client { Id = 2, Name = "Anders", Surname = "Hansen", CountryId = 3, ChannelId = 2, Email = "anders.hansen@gmail.com" }, new Client { Id = 3, Name = "Fabricio", Surname = "Bianchi", CountryId = 2, ChannelId = 1, Email = "fabricio.bianchi@gmail.com" }, new Client { Id = 4, Name = "Andy", Surname = "Smith", CountryId = 4, ChannelId = 1, Email = "andy.smith@gmail.com" }, new Client { Id = 5, Name = "Jan", Surname = "Vrba", CountryId = 6, ChannelId = 2, Email = "jan.vrba@gmail.com" }, new Client { Id = 6, Name = "Alexander", Surname = "Sidorov", CountryId = 5, ChannelId = 2, Email = "alex.sidorov@gmail.com" });
            modelBuilder.Entity<Software>().HasData(new Software { Id = 1, Name = "Visual Studio", SoftwareTypeId = 1, PackageVersion = Guid.NewGuid() }, new Software { Id = 2, Name = "Visual Studio Code", SoftwareTypeId = 2, PackageVersion = Guid.NewGuid() }, new Software { Id = 3, Name = "Kaspersky", SoftwareTypeId = 3, PackageVersion = Guid.NewGuid() }, new Software { Id = 4, Name = "Avast Antivirus", SoftwareTypeId = 1, PackageVersion = Guid.NewGuid() }, new Software { Id = 5, Name = "Azure CLI", SoftwareTypeId = 3, PackageVersion = Guid.NewGuid() });
            modelBuilder.Entity<SoftwareType>().HasData(new SoftwareType { Id = 1, Name = "Firmware"}, new SoftwareType { Id = 2, Name = "PC Installation" }, new SoftwareType { Id = 3, Name = "Single File" });
            modelBuilder.Entity<Version>().HasData(new Version { Id = 1, VersionCode = 3 }, new Version { Id = 2, VersionCode = 2 }, new Version { Id = 3, VersionCode = 1 });
            modelBuilder.Entity<Channel>().HasData(new Channel { Id = 1, Name = "Public" }, new Channel { Id = 2, Name = "Internal Beta" }, new Channel { Id = 3, Name = "Insider" });
            modelBuilder.Entity<ClientSoftwareVersion>().HasData(new ClientSoftwareVersion { ClientId = 1, SoftwareId = 1, VersionId = 1 }, new ClientSoftwareVersion { ClientId = 1, SoftwareId = 2, VersionId = 2 }, new ClientSoftwareVersion { ClientId = 2, SoftwareId = 1, VersionId = 2 }, new ClientSoftwareVersion { ClientId = 4, SoftwareId = 3, VersionId = 2 });
            modelBuilder.Entity<SoftwareChannel>().HasData(new SoftwareChannel { SoftwareId = 1, ChannelId = 1 }, new SoftwareChannel { SoftwareId = 1, ChannelId = 3 }, new SoftwareChannel { SoftwareId = 2, ChannelId = 2 });
            modelBuilder.Entity<SoftwareVersion>().HasData(new SoftwareVersion { SoftwareId = 1, VersionId = 1, ReleaseDate = new DateTime(2017, 5, 12) }, new SoftwareVersion { SoftwareId = 1, VersionId = 3, ReleaseDate = new DateTime(2022, 8, 7) }, new SoftwareVersion { SoftwareId = 2, VersionId = 2, ReleaseDate = new DateTime(2019, 3, 10) });
            modelBuilder.Entity<SoftwareCountry>().HasData(new SoftwareCountry { SoftwareId = 1, CountryId = 1 }, new SoftwareCountry { SoftwareId = 1, CountryId = 2 }, new SoftwareCountry { SoftwareId = 1, CountryId = 4 }, new SoftwareCountry { SoftwareId = 2, CountryId = 5 }, new SoftwareCountry { SoftwareId = 2, CountryId = 6 }, new SoftwareCountry { SoftwareId = 2, CountryId = 4 }, new SoftwareCountry { SoftwareId = 3, CountryId = 5 }, new SoftwareCountry { SoftwareId = 4, CountryId = 6 }, new SoftwareCountry { SoftwareId = 4, CountryId = 4 });
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<ClientSoftwareVersion> ClientSoftwareVersion { get; set; }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<Version> Version { get; set; }
        public DbSet<SoftwareChannel> SoftwareChannel { get; set; }
        public DbSet<SoftwareVersion> SoftwareVersion { get; set; }
        public DbSet<SoftwareType> SoftwareType { get; set; }
        public DbSet<SoftwareCountry> SoftwareCountry { get; set; }
    }
}
