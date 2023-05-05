using Marketplace.Domain.Entities;
using NetDevPack.Data;

namespace Marketplace.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetAll();
        Task<List<Order>> GetAllByBuyer(Guid userBuyerId);
        Task<Order> GetById(Guid id);
        void Create(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}