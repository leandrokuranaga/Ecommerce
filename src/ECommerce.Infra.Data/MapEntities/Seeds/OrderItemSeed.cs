using Ecommerce.Domain.OrderItemAggregate;

namespace ECommerce.Infra.Data.MapEntities.Seeds
{
    public static class OrderItemSeed
    {
        public static List<OrderItemDomain> OrderItems()
        {
            return
            [
                new OrderItemDomain
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    ProductName = "Product A",
                    Quantity = 2,
                    UnitPrice = 50.00m
                },
                new OrderItemDomain
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 3,
                    ProductName = "Product B",
                    Quantity = 1,
                    UnitPrice = 50.75m
                },
                new OrderItemDomain
                {
                    Id = 3,
                    OrderId = 2,
                    ProductId = 2,
                    ProductName = "Smartphone Samsung Galaxy S21",
                    Quantity = 1,
                    UnitPrice = 3500.00m
                }
            ];
        }
    }
}
