using Marketplace.Domain.Entities;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Marketplace.Infra.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly MarketplaceContext Db;
        private readonly DbSet<OrderItem> DbSet;

        public OrderItemRepository(MarketplaceContext db)
        {
            Db = db;
            DbSet = Db.Set<OrderItem>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void CreateMultiple(List<OrderItem> orderItems)
        {
            DbSet.AddRange(orderItems);
        }

        public void DeleteByOrderId(Guid orderId)
        {
            var orderItems = DbSet
                .FromSqlInterpolated($@"Select * FROM operation.order_item where order_id = {orderId}");

            DbSet.RemoveRange(orderItems);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}