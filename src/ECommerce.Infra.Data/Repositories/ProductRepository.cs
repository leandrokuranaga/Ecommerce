using Ecommerce.Domain.ProductAggregate;
using ECommerce.Infra.Data.Repositories.Base;

namespace ECommerce.Infra.Data.Repositories
{
    public class ProductRepository(IUnitOfWork unitOfWork) : BaseRepository<ProductDomain>(unitOfWork), IProductRepository
    {
    }
}
