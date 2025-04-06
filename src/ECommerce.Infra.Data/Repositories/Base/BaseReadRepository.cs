using MongoDB.Driver;
using System.Linq.Expressions;
using Ecommerce.Domain.SeedWork;

namespace ECommerce.Infra.Data.Mongo.Base
{
    public abstract class BaseReadRepository<T>(IMongoCollection<T> collection) : IBaseReadRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection = collection;

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task<T?> GetByIdAsync(int id)
            => await _collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();

        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> filter)
            => await _collection.Find(filter).FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
            => await _collection.Find(filter).ToListAsync();
    }
}
