using Ecommerce.Domain.OrderAggregate;
using ECommerce.Infra.Data.Repositories.Base;

namespace ECommerce.Infra.Data.Repositories
{
    public class OrderRepository(IUnitOfWork unitOfWork) : BaseRepository<OrderDomain>(unitOfWork), IOrderRepository
    {
    }
}
