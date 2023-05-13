using Marketplace.Domain.Entities;
using NetDevPack.Data;

namespace Marketplace.Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(Guid id);

        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}