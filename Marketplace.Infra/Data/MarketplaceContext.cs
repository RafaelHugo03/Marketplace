using Marketplace.Core.Entities;
using Marketplace.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Messaging;

namespace Marketplace.Infra.Data
{
    public class MarketplaceContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }

        public MarketplaceContext(DbContextOptions<MarketplaceContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Ignore<Event>();
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}