using Ecommerce.Application.Commands.Product;
using Ecommerce.Application.Queries.Product;
using Ecommerce.Domain;
using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.OrderItemAggregate;
using Ecommerce.Domain.ProductAggregate;
using Ecommerce.Domain.UserAggregate;
using Ecommerce.ReadModels.Dtos;
using ECommerce.Infra.Data;
using ECommerce.Infra.Data.Repositories;
using ECommerce.Infra.ServiceBus.Publishers;
using ECommerce.Infra.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ECommerce.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void AddLocalHttpClients(this IServiceCollection services, IConfiguration configuration) { }

        public static void AddLocalServices(this IServiceCollection services, IConfiguration configuration) 
        {

            #region repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            #endregion

            // Handlers - Comandos
            services.AddScoped<AddProductCommandHandler>();
            services.AddScoped<UpdateProductCommandHandler>();
            services.AddScoped<DeleteProductCommandHandler>();

            // Handlers - Queries
            services.AddScoped<GetAllProductsQueryHandler>();
            services.AddScoped<GetProductByIdQueryHandler>();

            // Mongo
            services.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var database = client.GetDatabase("ecommerce_read");
                return database.GetCollection<ProductDto>("products");
            });
        }

        public static void AddLocalDbContext(this IServiceCollection services, AppSettings settings)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(settings.ConnectionStrings.DefaultConnection));

            services.AddSingleton<IMongoClient>(_ =>
                new MongoClient(settings.ConnectionStrings.MongoConnection));

            services.AddSingleton<IServiceBusPublisher, ServiceBusPublisher>();
        }


    }
}
