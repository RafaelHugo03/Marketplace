
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Repositories;
using NetDevPack.Messaging;
using MediatR;
using FluentValidation.Results;

namespace Marketplace.Domain.CommandHandlers
{
    public class UserHandler : CommandHandler,
        IRequestHandler<RegisterUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>
    {
        private readonly IUserRepository userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var user = new User(Guid.NewGuid(),
                command.Name,
                command.EmailAddress,
                command.Password,
                command.BirthDate);

            if(await userRepository.GetUserByEmail(user.EmailAddress) != null)
            {
                AddError("Já existe um usuário cadastrado com esse e-mail");
                return ValidationResult;
            }

            userRepository.Create(user);

            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var user = await userRepository.GetUser(command.Id);
            
            user.UpdateUser(
                command.Name,
                command.EmailAddress,
                command.Password,
                command.BirthDate
            );

            userRepository.Update(user);

            return await Commit(userRepository.UnitOfWork);
        }
    }
}