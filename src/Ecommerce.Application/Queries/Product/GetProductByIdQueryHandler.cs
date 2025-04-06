using Ecommerce.Domain.ProductAggregate;
using Ecommerce.ReadModels.Dtos;

namespace Ecommerce.Application.Queries.Product
{
    public class GetProductByIdQueryHandler(IProductRepository repository)
    {
        public async Task<ProductDto> Handle(int id)
        {
            var product = await repository.GetByIdAsync(id, false);
            if (product == null)
                return null;

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
