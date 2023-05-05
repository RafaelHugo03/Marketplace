using AutoMapper;
using FluentValidation.Results;
using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Domain.Commands.OrderCommands;
using Marketplace.Domain.Repositories;
using NetDevPack.Mediator;

namespace Marketplace.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;

        public OrderService(IOrderRepository orderRepository, 
            IMapper mapper, 
            IMediatorHandler mediator)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ValidationResult> Cancelorder(OrderDTO dto)
        {
            var command = mapper.Map<CancelOrderCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<OrderDTO>> GetAll()
        {
            return mapper.Map<List<OrderDTO>>(await orderRepository.GetAll());
        }

        public async Task<List<OrderDTO>> GetAllByBuyer(Guid userBuyerId)
        {
            return mapper.Map<List<OrderDTO>>(await orderRepository.GetAllByBuyer(userBuyerId));
        }

        public async Task<OrderDTO> GetById(Guid id)
        {
            return mapper.Map<OrderDTO>(await orderRepository.GetById(id));
        }

        public async Task<ValidationResult> PayOrder(OrderDTO dto)
        {
            var command = mapper.Map<PayOrderCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Register(OrderDTO dto)
        {
            var command = mapper.Map<RegisterOrderCommand>(dto);
            return await mediator.SendCommand(command);
        }
    }
}