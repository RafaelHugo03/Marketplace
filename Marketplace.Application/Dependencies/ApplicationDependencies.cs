using Marketplace.Application.AutoMapper;
using Marketplace.Application.Services;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Marketplace.Application.Dependencies
{
    public static class ApplicationDependencies
    {
        public static void InjectApplicationDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMediatorHandler, InMemoryBus>();
            AddServices(serviceCollection);
            AddAutoMapperConfiguration(serviceCollection);
        }

        public static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IProductService, ProductService>();
        }

        public static void AddAutoMapperConfiguration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(DomainToViewModelMapper), typeof(ViewModelToDomainMapper));
        }
    }
}