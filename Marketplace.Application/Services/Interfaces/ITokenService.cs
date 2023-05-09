using Marketplace.Application.Models;

namespace Marketplace.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
    }
}