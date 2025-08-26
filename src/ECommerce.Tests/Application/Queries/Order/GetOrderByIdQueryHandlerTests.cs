using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.OrderItemAggregate;
using Ecommerce.Application.Queries.Order;
using Ecommerce.ReadModels.Dtos;

namespace ECommerce.Tests.Application.Queries.Order
{
    public class GetOrderByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ExistingOrder_ReturnsOrderDetails()
        {
            // Arrange
            var mockRepository = new MockOrderRepository();
            var handler = new GetOrderByIdQueryHandler(mockRepository);

            // Act
            var result = await handler.Handle(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Processing", result.Status);
            Assert.Equal(new DateTime(2023, 10, 26), result.OrderDate);
            Assert.Equal(150.75m, result.Total);
            Assert.Equal("123 Flower Street", result.DeliveryAddress);
            Assert.Equal(2, result.Items.Count);
            
            // Verify items
            var productA = result.Items.FirstOrDefault(i => i.ProductName == "Product A");
            Assert.NotNull(productA);
            Assert.Equal(2, productA.Quantity);
            Assert.Equal(50.00m, productA.UnitPrice);
            
            var productB = result.Items.FirstOrDefault(i => i.ProductName == "Product B");
            Assert.NotNull(productB);
            Assert.Equal(1, productB.Quantity);
            Assert.Equal(50.75m, productB.UnitPrice);
        }

        [Fact]
        public async Task Handle_NonExistentOrder_ReturnsNull()
        {
            // Arrange
            var mockRepository = new MockOrderRepository();
            var handler = new GetOrderByIdQueryHandler(mockRepository);

            // Act
            var result = await handler.Handle(99999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void TotalCalculation_IsCorrect()
        {
            // Arrange
            var order = new OrderDomain
            {
                Items = new List<OrderItemDomain>
                {
                    new OrderItemDomain { Quantity = 2, UnitPrice = 50.00m },
                    new OrderItemDomain { Quantity = 1, UnitPrice = 50.75m }
                }
            };

            // Act
            var total = order.Total;

            // Assert
            Assert.Equal(150.75m, total);
        }
    }

    // Mock repository for testing
    public class MockOrderRepository : IOrderRepository
    {
        private readonly List<OrderDomain> _orders = new()
        {
            new OrderDomain
            {
                Id = 1,
                CreatedAt = new DateTime(2023, 10, 26),
                Status = "Processing",
                UserId = 1,
                Items = new List<OrderItemDomain>
                {
                    new OrderItemDomain { ProductName = "Product A", Quantity = 2, UnitPrice = 50.00m },
                    new OrderItemDomain { ProductName = "Product B", Quantity = 1, UnitPrice = 50.75m }
                }
            }
        };

        public async Task<OrderDomain?> GetOrderWithItemsAsync(int id)
        {
            await Task.Delay(1); // Simulate async
            return _orders.FirstOrDefault(o => o.Id == id);
        }

        // Other interface methods (not implemented for test)
        public Task<OrderDomain> InsertOrUpdateAsync(OrderDomain entity) => throw new NotImplementedException();
        public Task<IEnumerable<OrderDomain>> InsertRangeAsync(IEnumerable<OrderDomain> entity) => throw new NotImplementedException();
        public Task UpdateAsync(OrderDomain entity) => throw new NotImplementedException();
        public IQueryable<OrderDomain> GetAll() => throw new NotImplementedException();
        public Task<OrderDomain> GetOneNoTracking(System.Linq.Expressions.Expression<Func<OrderDomain, bool>> expression) => throw new NotImplementedException();
        public Task<OrderDomain> GetOneTracking(System.Linq.Expressions.Expression<Func<OrderDomain, bool>> expression) => throw new NotImplementedException();
        public Task<IEnumerable<OrderDomain>> GetNoTrackingAsync(System.Linq.Expressions.Expression<Func<OrderDomain, bool>> expression) => throw new NotImplementedException();
        public Task<bool> ExistAsync(System.Linq.Expressions.Expression<Func<OrderDomain, bool>> expression) => throw new NotImplementedException();
        public Task<IEnumerable<OrderDomain>> GetAsync(System.Linq.Expressions.Expression<Func<OrderDomain, bool>> expression) => throw new NotImplementedException();
        public Task<OrderDomain> GetByIdAsync(int id, bool noTracking) => throw new NotImplementedException();
        public IQueryable<OrderDomain> Get(System.Linq.Expressions.Expression<Func<OrderDomain, bool>> expression) => throw new NotImplementedException();
        public Task<IEnumerable<OrderDomain>> GetAllAsync() => throw new NotImplementedException();
        public IQueryable<OrderDomain> Include<TProperty>(IQueryable<OrderDomain> query, System.Linq.Expressions.Expression<Func<OrderDomain, TProperty>> path) => throw new NotImplementedException();
        public Task DeleteAsync(OrderDomain entity) => throw new NotImplementedException();
        public Task AddRangeAsync(IEnumerable<OrderDomain> entities) => throw new NotImplementedException();
        public Task UpdateRangeAsync(IEnumerable<OrderDomain> entities) => throw new NotImplementedException();
        public Task UpdateRangeNoTrackingAsync(IEnumerable<OrderDomain> entities) => throw new NotImplementedException();
    }
}