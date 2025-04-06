using Ecommerce.Domain.ProductAggregate;
using Ecommerce.ReadModels.Dtos;
using ECommerce.Infra.ServiceBus.Publishers;
using System.Text.Json;

namespace Ecommerce.Application.Commands.Product
{
    public class AddProductCommandHandler(IProductRepository productRepository, IServiceBusPublisher busPublisher)
    {
        public async Task<ProductDto> Handle(AddProductCommand command)
        {
            var product = new ProductDomain
            {
                Name = command.Name,
                Price = command.Price,
                Stock = command.Stock,
                SellerId = command.SellerId
            };

            await productRepository.InsertOrUpdateAsync(product);

            var message = JsonSerializer.Serialize(new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Stock
            });

            busPublisher.PublishToDirect(message, routingKey: "product.created", exchange: "product.direct");

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
