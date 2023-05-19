using FluentValidation;
using Marketplace.Domain.Commands.UserCommands;

namespace Marketplace.Domain.Validations.CommandValidations.UserCommands
{
    public abstract class UserCommandValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateEmail()
        { 
            RuleFor(u => u.EmailAddress)
                .NotEmpty().WithMessage("E-mail não pode ser vazio")
                .EmailAddress();
        }

        protected void ValidatePassword()
        { 
            RuleFor(u => u.Password)
                .MinimumLength(8).WithMessage("Senha deve ser maior que 8 caracteres");
        }

        protected void ValidateName()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("E-mail não pode ser vazio")
                .Length(2, 100).WithMessage("Nome deve conter no mínimo 2 caracteres e no máximo 100");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.BirthDate)
                .Must(ValidateDate)
                .WithMessage("Data de nascimento não pode ser vazia");
        }

        protected void ValidateId()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("Id não pode ser nulo");
        }

        private bool ValidateDate(DateTime date)
        {
            return date != null && date != DateTime.MinValue && date != DateTime.MaxValue;
        }
    }
}