using FluentValidation;
using Marketplace.Domain.Commands.CategoryCommands;

namespace Marketplace.Domain.Validations.CommandValidations.CategoryCommands
{
    public class CategoryCommandValitadion<T> : AbstractValidator<T> where T : CategoryCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id não pode ser nulo");
        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Insira um nome válido");
        }
    }
}