using Abp.Domain.Entities;
using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.SeedWork.Enums;

namespace Ecommerce.Domain.UserAggregate
{
    public class UserDomain : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TypeUser Role { get; set; }

        public int OrderId { get; set; }
        public virtual ICollection<OrderDomain> Orders { get; set; } = [];
    }
}
