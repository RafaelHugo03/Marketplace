using FluentValidation.Results;
using Marketplace.Application.Models;

namespace Marketplace.Application.Services.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<List<ProductDTO>> GetAll();
        Task<List<ProductDTO>> GetAllByUser(Guid id);
        Task<ProductDTO> GetById(Guid id);

        Task<ValidationResult> Register(ProductDTO dto);
        Task<ValidationResult> Update(ProductDTO dto);
    }
}