using FluentValidation.Results;
using Marketplace.Application.Models;

namespace Marketplace.Application.Services.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<List<UserDTO>> GetAll();
        Task<UserDTO> GetById(Guid id);

        Task<ValidationResult> Register(UserDTO dto);
        Task<ValidationResult> Update(UserDTO dto);
        Task<ValidationResult> Delete(UserDTO dto);
    }
}