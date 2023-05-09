using FluentValidation.Results;
using Marketplace.Domain.Commands.OrderCommands;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Repositories;
using MediatR;
using NetDevPack.Messaging;

namespace Marketplace.Domain.CommandHandlers
{
    public class OrderHandler : CommandHandler,
        IRequestHandler<RegisterOrderCommand, ValidationResult>,
        IRequestHandler<CancelOrderCommand, ValidationResult>,
        IRequestHandler<PayOrderCommand, ValidationResult>
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public OrderHandler(IOrderRepository orderRepository, 
            IOrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public async Task<ValidationResult> Handle(RegisterOrderCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;
            
            command.CalculateTotalPrice();
            var order = command.ToEntity();

            var orderItems = command.OrderItems.Select(oi => oi.ToEntity()).ToList();

            orderItems.ForEach(oi => 
            {
                oi.Id = Guid.NewGuid();
                oi.SetOrderId(order.Id);
            });

            orderRepository.Create(order);
            orderItemRepository.CreateMultiple(order.OrderItems);

            return await Commit(orderRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var order = await orderRepository.GetById(command.Id);

            order.CancelOrder();
            orderRepository.Update(order);

            return await Commit(orderRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(PayOrderCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var order = await orderRepository.GetById(command.Id);

            order.PayOrder();
            orderRepository.Update(order);

            return await Commit(orderRepository.UnitOfWork);
        }
    }
}