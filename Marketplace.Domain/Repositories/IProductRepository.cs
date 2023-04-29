using Marketplace.Domain.Entities;
using NetDevPack.Data;

namespace Marketplace.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetAllByUser(Guid userSellerId);
        Task<Product> GetById(Guid userSellerId);
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}