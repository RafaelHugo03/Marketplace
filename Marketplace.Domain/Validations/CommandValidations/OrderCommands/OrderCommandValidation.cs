using FluentValidation;
using Marketplace.Domain.Commands.OrderCommands;
using Marketplace.Domain.Commands.OrderItemCommands;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Validations.CommandValidations.OrderCommands
{
    public class OrderCommandValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateId()
        {
            RuleFor(o => o.Id)
                .NotEmpty().WithMessage("Id não pode ser nulo");
        }

        protected void ValidateUserBuyerId()
        {
            RuleFor(o => o.UserBuyerId)
                .NotEmpty().WithMessage("Id do comprador não pode ser nulo");
        }

        protected void ValidateTotalPrice()
        {
            RuleFor(o => o.TotalPrice)
                .GreaterThan(0).WithMessage("Preço total deve ser maios que 0");
        }

        protected void ValidateProductIds()
        {
            RuleFor(o => o.OrderItems)
                .Must(ValidateOrderItems)
                .WithMessage("Insira ao menos um produto");
        }

        public bool ValidateOrderItems(List<RegisterOrderItemCommand> orderItems)
        {
            var invalidOrderItems = orderItems.Where(s => (s.Price <= 0) || (s.Quantity <= 0) || (s.ProductId == null));

            return !invalidOrderItems.Any();
        }
    }
}