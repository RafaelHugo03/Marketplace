using AutoMapper;
using FluentValidation.Results;
using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Repositories;
using NetDevPack.Mediator;

namespace Marketplace.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IMediatorHandler mediator;

        public UserService(IMapper mapper, IUserRepository userRepository, IMediatorHandler mediator)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.mediator = mediator;
        }

        public async Task<ValidationResult> Delete(UserDTO dto)
        {
            var command = mapper.Map<DeleteUserCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return mapper.Map<List<UserDTO>>(await userRepository.GetUsers());
        }

        public async Task<UserDTO> GetByEmail(string emailAddress)
        {
            return mapper.Map<UserDTO>(await userRepository.GetUserByEmail(emailAddress));
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            return mapper.Map<UserDTO>(await userRepository.GetUser(id));
        }

        public async Task<ValidationResult> Login(UserDTO dto)
        {
            var command = mapper.Map<LoginCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Register(UserDTO dto)
        {
            var command = mapper.Map<RegisterUserCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> RegisterAdmin(UserDTO dto)
        {
            var command = mapper.Map<RegisterAdminCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(UserDTO dto)
        {
            var command = mapper.Map<UpdateUserCommand>(dto);
            return await mediator.SendCommand(command);
        }
    }
}