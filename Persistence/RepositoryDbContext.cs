using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Version = Domain.Entities.Version;

namespace Persistence
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
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
