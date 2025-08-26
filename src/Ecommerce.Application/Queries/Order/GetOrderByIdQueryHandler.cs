using Ecommerce.Domain.OrderAggregate;
using Ecommerce.ReadModels.Dtos;

namespace Ecommerce.Application.Queries.Order
{
    public class GetOrderByIdQueryHandler(IOrderRepository repository)
    {
        public async Task<OrderDto?> Handle(int id)
        {
            var order = await repository.GetOrderWithItemsAsync(id);
            if (order == null)
                return null;

            return new OrderDto
            {
                Id = order.Id,
                Status = order.Status,
                OrderDate = order.CreatedAt,
                Total = order.Total,
                DeliveryAddress = "123 Flower Street", // TODO: Get from user address
                Items = order.Items.Select(item => new OrderItemDto
                {
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };
        }
    }
}