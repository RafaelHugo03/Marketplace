using AutoMapper;
using FluentValidation.Results;
using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Domain.Commands.CategoryCommands;
using Marketplace.Domain.Repositories;
using NetDevPack.Mediator;

namespace Marketplace.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;

        public CategoryService(ICategoryRepository categoryRepository, 
            IMapper mapper, 
            IMediatorHandler mediator)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ValidationResult> Delete(CategoryDTO dto)
        {
            var command = mapper.Map<DeleteCategoryCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            return mapper.Map<List<CategoryDTO>>(await categoryRepository.GetAll());
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
            return mapper.Map<CategoryDTO>(await categoryRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CategoryDTO dto)
        {
            var command = mapper.Map<RegisterCategoryCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(CategoryDTO dto)
        {
            var command = mapper.Map<UpdateCategoryCommand>(dto);
            return await mediator.SendCommand(command);
        }
    }
}