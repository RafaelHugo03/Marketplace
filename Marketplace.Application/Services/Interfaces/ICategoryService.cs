using FluentValidation.Results;
using Marketplace.Application.Models;

namespace Marketplace.Application.Services.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<List<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(Guid id);

        Task<ValidationResult> Register(CategoryDTO dto);
        Task<ValidationResult> Update(CategoryDTO dto);
        Task<ValidationResult> Delete(CategoryDTO dto);
    }
}