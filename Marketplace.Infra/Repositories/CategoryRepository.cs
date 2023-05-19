using Marketplace.Domain.Entities;
using Marketplace.Domain.Queries;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Marketplace.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketplaceContext Db;
        private readonly DbSet<Category> DbSet;

        public CategoryRepository(MarketplaceContext db)
        {
            Db = db;
            DbSet = db.Set<Category>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Create(Category category)
        {
            DbSet.Add(category);
        }

        public void Delete(Category category)
        {
            DbSet.Remove(category);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<List<Category>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await DbSet
                .AsNoTracking()
                .Where(CategoryQueries.GetById(id))
                .FirstOrDefaultAsync();
        }

        public void Update(Category category)
        {
            DbSet.Update(category);
        }
    }
}