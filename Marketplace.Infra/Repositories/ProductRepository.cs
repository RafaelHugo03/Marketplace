using Marketplace.Domain.Entities;
using Marketplace.Domain.Queries;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Marketplace.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketplaceContext Db;
        private readonly DbSet<Product> DbSet;

        public ProductRepository(MarketplaceContext context)
        {
            Db = context;
            DbSet = context.Set<Product>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Create(Product product)
        {
            DbSet.Add(product);
        }

        public void Delete(Product product)
        {
            DbSet.Remove(product);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<List<Product>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<List<Product>> GetAllByUser(Guid userSellerId)
        {
            return await DbSet
                .AsNoTracking()
                .Where(ProductQueries.GetBySeller(userSellerId))
                .ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(ProductQueries.GetById(id));
        }

        public void Update(Product product)
        {
            DbSet.Update(product);
        }
    }
}