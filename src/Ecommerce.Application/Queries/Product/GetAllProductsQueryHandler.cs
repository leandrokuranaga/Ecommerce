using Ecommerce.Domain.ProductAggregate;
using Ecommerce.ReadModels.Dtos;

namespace Ecommerce.Application.Queries.Product
{
    public class GetAllProductsQueryHandler(IProductRepository repository)
    {
        private readonly IProductRepository _repository = repository;

        public async Task<IEnumerable<ProductDto>> Handle()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });
        }
    }

}
