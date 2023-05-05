using FluentValidation.Results;
using Marketplace.Application.Models;

namespace Marketplace.Application.Services.Interfaces
{
    public interface IOrderService : IDisposable
    {
        Task<List<OrderDTO>> GetAll();
        Task<List<OrderDTO>> GetAllByBuyer(Guid userBuyerId);
        Task<OrderDTO> GetById(Guid id);

        Task<ValidationResult> Register(OrderDTO dto);
        Task<ValidationResult> Cancelorder(OrderDTO dto);
        Task<ValidationResult> PayOrder(OrderDTO dto);
    }
}