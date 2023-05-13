using FluentValidation.Results;
using Marketplace.Domain.Commands.CategoryCommands;
using Marketplace.Domain.Repositories;
using MediatR;
using NetDevPack.Messaging;

namespace Marketplace.Domain.CommandHandlers
{
    public class CategoryHandler : CommandHandler,
        IRequestHandler<RegisterCategoryCommand, ValidationResult>,
        IRequestHandler<UpdateCategoryCommand, ValidationResult>,
        IRequestHandler<DeleteCategoryCommand, ValidationResult>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<ValidationResult> Handle(RegisterCategoryCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var category = command.ToEntity();

            categoryRepository.Create(category);

            return await Commit(categoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var category = command.ToEntity();

            categoryRepository.Update(category);

            return await Commit(categoryRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            if(!command.IsValid()) return command.ValidationResult;

            var category = await categoryRepository.GetById(command.Id);

            categoryRepository.Delete(category);

            return await Commit(categoryRepository.UnitOfWork);
        }
    }
}