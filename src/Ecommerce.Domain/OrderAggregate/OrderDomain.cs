using Abp.Domain.Entities;
using Ecommerce.Domain.OrderItemAggregate;
using Ecommerce.Domain.UserAggregate;

namespace Ecommerce.Domain.OrderAggregate
{
    public class OrderDomain : Entity
    {
        public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
        public string Status { get; set; } = "Created";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public virtual ICollection<OrderItemDomain> Items { get; set; } = [];
        public virtual UserDomain User { get; set; }
    }
}
