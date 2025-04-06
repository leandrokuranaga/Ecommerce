using Ecommerce.Domain.ProductAggregate;
using Ecommerce.ReadModels.Dtos;
using MongoDB.Driver;
using ECommerce.Infra.Data.Mongo.Base;

namespace ECommerce.Infra.Data.Mongo.Read
{
    public class ProductReadRepository(IMongoCollection<ProductDto> collection) : BaseReadRepository<ProductDto>(collection), IProductReadRepository
    {
    }
}
