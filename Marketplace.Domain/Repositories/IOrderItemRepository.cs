using Marketplace.Domain.Entities;
using NetDevPack.Data;

namespace Marketplace.Domain.Repositories
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        void CreateMultiple(List<OrderItem> orderItems);
        void DeleteByOrderId(Guid orderId);
    }
}