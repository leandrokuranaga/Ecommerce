using Ecommerce.Domain.SeedWork;

namespace Ecommerce.Domain.OrderAggregate
{
    public interface IOrderRepository : IBaseRepository<OrderDomain>
    {
        Task<OrderDomain?> GetOrderWithItemsAsync(int id);
    }
}
