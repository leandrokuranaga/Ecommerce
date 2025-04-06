using Ecommerce.Domain.OrderItemAggregate;
using ECommerce.Infra.Data.Repositories.Base;

namespace ECommerce.Infra.Data.Repositories
{
    public class OrderItemRepository(IUnitOfWork unitOfWork) : BaseRepository<OrderItemDomain>(unitOfWork), IOrderItemRepository
    {
    }
}
