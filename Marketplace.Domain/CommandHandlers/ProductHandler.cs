using FluentValidation.Results;
using Marketplace.Domain.Commands.ProductCommands;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Repositories;
using MediatR;
using NetDevPack.Messaging;

namespace Marketplace.Domain.CommandHandlers
{
    public class ProductHandler : CommandHandler,
        IRequestHandler<RegisterProductCommand, ValidationResult>,
        IRequestHandler<UpdateProductCommand, ValidationResult>,
        IRequestHandler<DeleteProductCommand, ValidationResult>
    {
        private readonly IProductRepository productRepository;

        public ProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ValidationResult> Handle(RegisterProductCommand command, CancellationToken cancellationToken)
        {
           if(!command.IsValid()) return command.ValidationResult;

           var product = new Product(
            Guid.NewGuid(),
            command.Name,
            command.Description,
            command.Price,
            command.Quantity,
            command.UserSellerId
           );

           productRepository.Create(product);

           return await Commit(productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var product = await productRepository.GetById(command.Id);

            product.UpdateProduct(
                command.Name,
                command.Description,
                command.Price,
                command.Quantity
            );

            productRepository.Update(product);

            return await Commit(productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var product = await productRepository.GetById(command.Id);

            productRepository.Delete(product);

            return await Commit(productRepository.UnitOfWork);
        }
    }
}