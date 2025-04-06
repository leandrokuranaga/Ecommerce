using Ecommerce.Domain.OrderAggregate;
using System;
using System.Collections.Generic;

namespace ECommerce.Infra.Data.MapEntities.Seeds
{
    public static class OrderSeed
    {
        public static List<OrderDomain> Orders()
        {
            return
            [
                new OrderDomain
                {
                    Id = 1,
                    CreatedAt = new DateTime(2025, 4, 1),
                    Status = "Completed",
                    UserId = 1
                },
                new OrderDomain
                {
                    Id = 2,
                    CreatedAt = new DateTime(2025, 4, 2),
                    Status = "Pending",
                    UserId = 2
                }
            ];
        }
    }
}
