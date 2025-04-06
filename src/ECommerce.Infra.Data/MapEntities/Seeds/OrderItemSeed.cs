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
                    ProductName = "Notebook Dell Inspiron",
                    Quantity = 1,
                    UnitPrice = 4500.00m
                },
                new OrderItemDomain
                {
                    Id = 2,
                    OrderId = 1,
                    ProductId = 3,
                    ProductName = "Fone Bluetooth JBL",
                    Quantity = 2,
                    UnitPrice = 299.90m
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
