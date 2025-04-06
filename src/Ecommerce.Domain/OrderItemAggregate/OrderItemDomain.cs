using Abp.Domain.Entities;
using Ecommerce.Domain.OrderAggregate;

namespace Ecommerce.Domain.OrderItemAggregate
{
    public class OrderItemDomain : Entity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        public virtual OrderDomain Order { get; set; }
    }
}
