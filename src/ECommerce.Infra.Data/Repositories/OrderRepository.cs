using Ecommerce.Domain.OrderAggregate;
using ECommerce.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Data.Repositories
{
    public class OrderRepository(IUnitOfWork unitOfWork) : BaseRepository<OrderDomain>(unitOfWork), IOrderRepository
    {
        public async Task<OrderDomain?> GetOrderWithItemsAsync(int id)
        {
            return await _unitOfWork.Context.Set<OrderDomain>()
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
