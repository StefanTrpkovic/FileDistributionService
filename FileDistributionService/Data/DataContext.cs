using FileDistributionService.Entity;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Software>().HasOne(cl => cl.Country).WithMany(c => c.Softwares).HasForeignKey(cl => cl.CountryId);
            modelBuilder.Entity<ClientSoftware>().HasKey(cls => new { cls.ClientId, cls.SoftwareId });
            modelBuilder.Entity<ClientSoftware>().HasOne(cls => cls.Client).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.ClientId);
            modelBuilder.Entity<ClientSoftware>().HasOne(cls => cls.Software).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.SoftwareId);
            modelBuilder.Entity<SoftwareChannel>().HasKey(sc => new { sc.SoftwareId, sc.ChannelId });
            modelBuilder.Entity<SoftwareChannel>().HasOne(sc => sc.Software).WithMany(s => s.SoftwareChannels).HasForeignKey(sc => sc.SoftwareId);
            modelBuilder.Entity<SoftwareChannel>().HasOne(sc => sc.Channel).WithMany(c => c.SoftwareChannels).HasForeignKey(sc => sc.ChannelId);
            modelBuilder.Entity<SoftwareVersion>().HasKey(sv => new { sv.SoftwareId, sv.VersionId });
            modelBuilder.Entity<SoftwareVersion>().HasOne(sv => sv.Software).WithMany(s => s.SoftwareVersions).HasForeignKey(sv => sv.SoftwareId);
            modelBuilder.Entity<SoftwareVersion>().HasOne(sv => sv.SoftVersion).WithMany(v => v.SoftwareVersions).HasForeignKey(sv => sv.VersionId);

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Macedonia" }, new Country { Id = 2, Name = "Italy" }, new Country { Id = 3, Name = "Denmark" }, new Country { Id = 4, Name = "USA" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, Name = "Stefan", CountryId = 1, ChannelId = 3 }, new Client { Id = 2, Name = "Anders", CountryId = 3, ChannelId = 2 }, new Client { Id = 3, Name = "Fabricio", CountryId = 2, ChannelId = 1 });
            modelBuilder.Entity<Software>().HasData(new Software { Id = 1, Name = "Visual Studio", CountryId = 1 }, new Software { Id = 2, Name = "Visual Studio Code", CountryId = 2 }, new Software { Id = 3, Name = "Zoom", CountryId = 4 });
            modelBuilder.Entity<SoftVersion>().HasData(new SoftVersion { Id = 1, Code = "3" }, new SoftVersion { Id = 2, Code = "2" }, new SoftVersion { Id = 3, Code = "1" });
            modelBuilder.Entity<Channel>().HasData(new Channel { Id = 1, Name = "Public" }, new Channel { Id = 2, Name = "Internal Beta" }, new Channel { Id = 3, Name = "Insider" });
            modelBuilder.Entity<ClientSoftware>().HasData(new ClientSoftware { ClientId = 1, SoftwareId = 1 }, new ClientSoftware { ClientId = 1, SoftwareId = 2 }, new ClientSoftware { ClientId = 2, SoftwareId = 1 });
            modelBuilder.Entity<SoftwareChannel>().HasData(new SoftwareChannel { SoftwareId = 1, ChannelId = 1 }, new SoftwareChannel { SoftwareId = 1, ChannelId = 3 }, new SoftwareChannel { SoftwareId = 2, ChannelId = 2 });
            modelBuilder.Entity<SoftwareVersion>().HasData(new SoftwareVersion { SoftwareId = 1, VersionId = 1 }, new SoftwareVersion { SoftwareId = 1, VersionId = 3 }, new SoftwareVersion { SoftwareId = 2, VersionId = 2 });
        }
        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<ClientSoftware> ClientSoftware { get; set; }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<SoftVersion> SoftVersion { get; set; }
        public DbSet<SoftwareChannel> SoftwareChannel { get; set; }
        public DbSet<SoftwareVersion> SoftwareVersion { get; set; }
    }
}
