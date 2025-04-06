using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.OrderItemAggregate;
using Ecommerce.Domain.UserAggregate;
using ECommerce.Infra.Data.MapEntities.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infra.Data.MapEntities
{
    public class OrderItemsMap : IEntityTypeConfiguration<OrderItemDomain>
    {
        public void Configure(EntityTypeBuilder<OrderItemDomain> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnName("ProductId");

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnName("ProductName")
                .HasMaxLength(100);

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnName("UnitPrice")
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(OrderItemSeed.OrderItems());
        }

    }
}
