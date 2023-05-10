using Marketplace.Application.Models;
using Microsoft.AspNetCore.Http;

namespace Marketplace.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDTO user);
        Guid GetIdInToken(HttpRequest request);
    }
}