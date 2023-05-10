
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Repositories;
using NetDevPack.Messaging;
using MediatR;
using FluentValidation.Results;
using SecureIdentity.Password;

namespace Marketplace.Domain.CommandHandlers
{
    public class UserHandler : CommandHandler,
        IRequestHandler<RegisterUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>,
        IRequestHandler<DeleteUserCommand, ValidationResult>,
        IRequestHandler<LoginCommand, ValidationResult>,
        IRequestHandler<RegisterAdminCommand, ValidationResult>
    {
        private readonly IUserRepository userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            command.PasswordToHash();

            var user = command.ToEntity();

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

            command.PasswordToHash();
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

        public async Task<ValidationResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var user = await userRepository.GetUser(command.Id);

            userRepository.Delete(user);

            return await Commit(userRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var user = await userRepository.GetUserByEmail(command.EmailAddress);

            if(user == null)
            {
                AddError("E-mail incorreto");
                return command.ValidationResult;
            }

            var passwordIsValid = PasswordHasher.Verify(user.Password, command.Password);

            if(!passwordIsValid)
            {
                AddError("Senha inválida");
                return command.ValidationResult;
            }
            
            return command.ValidationResult;
        }

        public async Task<ValidationResult> Handle(RegisterAdminCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            command.PasswordToHash();
            var user = command.ToEntity();

            userRepository.Create(user);

            return await Commit(userRepository.UnitOfWork);
        }
    }
}