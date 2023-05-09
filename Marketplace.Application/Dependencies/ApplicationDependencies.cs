using System.Text;
using Marketplace.Application.AutoMapper;
using Marketplace.Application.Services;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Application.Settings;
using Marketplace.Infra.Bus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
            AddAuthentication(serviceCollection);
        }

        public static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
        }

        public static void AddAuthentication(IServiceCollection serviceCollection)
        {
            var key = Encoding.ASCII.GetBytes(TokenSettings.SecretKey);

            serviceCollection.AddAuthentication(opt => 
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt => 
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true, 
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false   
                };
            });
        }

        public static void AddAutoMapperConfiguration(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(DomainToViewModelMapper), typeof(ViewModelToDomainMapper));
        }
    }
}