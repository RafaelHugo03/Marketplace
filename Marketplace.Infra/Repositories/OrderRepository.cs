using Marketplace.Domain.Entities;
using Marketplace.Domain.Queries;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Marketplace.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MarketplaceContext Db;
        private readonly DbSet<Order> DbSet;

        public OrderRepository(MarketplaceContext db)
        {
            Db = db;
            DbSet = Db.Set<Order>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Create(Order order)
        {
            Db.Add(order);
        }

        public void Delete(Order order)
        {
            Db.Remove(order);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<List<Order>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<List<Order>> GetAllByBuyer(Guid userBuyerId)
        {
            return await DbSet.AsNoTracking().Where(OrderQueries.GetByBuyerId(userBuyerId)).ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().Where(OrderQueries.GetById(id)).FirstOrDefaultAsync();
        }

        public void Update(Order order)
        {
            Db.Update(order);
        }
    }
}