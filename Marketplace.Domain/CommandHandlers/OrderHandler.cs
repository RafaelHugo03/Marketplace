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
        private readonly IProductRepository productRepository;

        public OrderHandler(IOrderRepository orderRepository, 
            IOrderItemRepository orderItemRepository,
            IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.productRepository = productRepository;
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

            var productIds = orderItems.Select(s => s.ProductId).ToArray();
            var products = await productRepository.GetAllByIds(productIds);

            foreach(var id in productIds)
            {
                var orderItem = orderItems.Where(s => s.ProductId == id).FirstOrDefault();
                var product = products.Where(p => p.Id == id).FirstOrDefault();

                if(product.Quantity - orderItem.Quantity < 0) {
                    AddError($"Temos apenas {product.Quantity} disponíveis do produto {product.Name}");
                    return command.ValidationResult;
                }

                product.SubtractQuantity(orderItem.Quantity);
                productRepository.Update(product);
            }

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