using Abp.Domain.Entities;
using Ecommerce.Domain.UserAggregate;

namespace Ecommerce.Domain.ProductAggregate
{
    public class ProductDomain : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int SellerId { get; set; }  

        public virtual UserDomain User { get; set; }
    }
}
