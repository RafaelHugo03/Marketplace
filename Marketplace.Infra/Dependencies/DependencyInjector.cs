using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Marketplace.Domain.CommandHandlers;
using Marketplace.Domain.Commands.ProductCommands;
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Data;
using Marketplace.Infra.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Infra.Dependencies
{
    public static class DependencyInjector
    {
        public static void AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresConnection");

            serviceCollection.AddDbContext<MarketplaceContext>(opt => opt.UseNpgsql(connectionString));
        }

        public static void InjectDependencies(this IServiceCollection serviceCollection)
        {
            AddRepositories(serviceCollection);
            AddHandlers(serviceCollection);
        }

        public static void AddHandlers(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRequestHandler<RegisterUserCommand, ValidationResult>, UserHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateUserCommand, ValidationResult>, UserHandler>();

            serviceCollection.AddScoped<IRequestHandler<RegisterProductCommand, ValidationResult>, ProductHandler>();
            serviceCollection.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductHandler>();
        }

        public static void AddRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }

    }
}