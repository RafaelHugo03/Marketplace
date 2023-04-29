using FluentValidation;
using Marketplace.Domain.Commands.ProductCommands;

namespace Marketplace.Domain.Validations.CommandValidations.ProductCommands
{
    public class ProductCommandValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Nome não pode ser nulo ou vazio");
        }

        protected void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .GreaterThan(0).WithName("Preço deve ser maior que 0");
        }

        protected void ValidateUserSellerId()
        {
            RuleFor(p => p.UserSellerId)
                .NotEmpty().WithMessage("Id do usuário vendedor não pode ser nulo");
        }

        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id do produto não pode ser nulo");
        }

        protected void ValidateQuantity()
        {
            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("Quantidade deve ser maior que 0");
        }
    }
}