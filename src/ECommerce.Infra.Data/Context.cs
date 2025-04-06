using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.OrderItemAggregate;
using Ecommerce.Domain.ProductAggregate;
using Ecommerce.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.Migrate();            
        }

        public DbSet<OrderItemDomain> OrderItems { get; set; }
        public DbSet<OrderDomain> Orders { get; set; }
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<ProductDomain> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
