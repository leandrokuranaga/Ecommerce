using Ecommerce.Domain.ProductAggregate;

namespace ECommerce.Infra.Data.MapEntities.Seeds
{
    public static class ProductSeed
    {
        public static List<ProductDomain> Products()
        {
            var products = new List<ProductDomain>
            {
                new() {
                    Id = 1,
                    Name = "Notebook Dell Inspiron",
                    Price = 4500.00m,
                    Stock = 10,
                    SellerId = 1
                },
                new() {
                    Id = 2,
                    Name = "Smartphone Samsung Galaxy S21",
                    Price = 3500.00m,
                    Stock = 25,
                    SellerId = 2
                },
                new() {
                    Id = 3,
                    Name = "Fone Bluetooth JBL",
                    Price = 299.90m,
                    Stock = 50,
                    SellerId = 1
                }
            };

            return products;
        }
    }
}
