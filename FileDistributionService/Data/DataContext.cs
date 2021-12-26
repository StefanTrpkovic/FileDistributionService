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
            modelBuilder.Entity<Client>().HasOne<Country>(cl => cl.Country).WithMany(c => c.Clients).HasForeignKey(cl => cl.CountryId);
            modelBuilder.Entity<ClientSoftware>().HasKey(cls => new { cls.ClientId, cls.SoftwareId });
            modelBuilder.Entity<ClientSoftware>().HasOne<Client>(cls => cls.Client).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.ClientId);
            modelBuilder.Entity<ClientSoftware>().HasOne<Software>(cls => cls.Software).WithMany(cl => cl.ClientSoftwares).HasForeignKey(cls => cls.SoftwareId);

            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Spain" });
            modelBuilder.Entity<Client>().HasData(new Client { Id = 1, Name = "Stefan", CountryId = 1 });
            modelBuilder.Entity<Software>().HasData(new Software { Id = 1, Name = "Visual Studio" });
            modelBuilder.Entity<ClientSoftware>().HasData(new ClientSoftware { ClientId = 1, SoftwareId = 1 });
        }

       


        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<ClientSoftware> ClientSoftware { get; set; }
    }
}
