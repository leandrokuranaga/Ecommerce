using Ecommerce.Domain.ProductAggregate;
using Ecommerce.ReadModels.Dtos;

namespace Ecommerce.Application.Commands.Product
{
    public class UpdateProductCommandHandler(IProductRepository repository)
    {
        public async Task<ProductDto> Handle(UpdateProductCommand command)
        {
            var product = await repository.GetByIdAsync(command.Id, false);
            if (product == null)
                return null;

            product.Name = command.Name;
            product.Price = command.Price;
            product.Stock = command.Stock;

            await repository.UpdateAsync(product);

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
