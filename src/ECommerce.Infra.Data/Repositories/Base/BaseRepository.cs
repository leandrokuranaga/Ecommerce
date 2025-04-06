using Ecommerce.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ECommerce.Infra.Data.Repositories.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseRepository<TEntity>(IUnitOfWork unitOfWork) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> InsertRangeAsync(IEnumerable<TEntity> entity)
        {
            await _unitOfWork.Context.Set<TEntity>().AddRangeAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<TEntity> GetAll() => _unitOfWork.Context.Set<TEntity>().AsQueryable();

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression) => await GetAll().Where(expression).ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id, bool noTracking) => await _unitOfWork.Context.Set<TEntity>().FindAsync(id);

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression) => GetAll().Where(expression);

        public virtual IQueryable<TEntity> Include<TProperty>(IQueryable<TEntity> query, Expression<Func<TEntity, TProperty>> path) => query.Include(path);

        public async Task DeleteAsync(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await GetAll().ToListAsync();

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> expression) => await _unitOfWork.Context.Set<TEntity>().AsNoTracking().AnyAsync(expression);

        public async Task<TEntity> GetOneNoTracking(Expression<Func<TEntity, bool>> expression) => await _unitOfWork.Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression);

        public async Task<TEntity> GetOneTracking(Expression<Func<TEntity, bool>> expression) => await _unitOfWork.Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression);
        public async Task<IEnumerable<TEntity>> GetNoTrackingAsync(Expression<Func<TEntity, bool>> expression) => await GetAll().AsNoTracking().Where(expression).ToListAsync();

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _unitOfWork.Context.Set<TEntity>().AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Context.Set<TEntity>().UpdateRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRangeNoTrackingAsync(IEnumerable<TEntity> entities)
        {
            _unitOfWork.Context.AttachRange(entities);
            _unitOfWork.Context.Set<TEntity>().UpdateRange(entities);
            await _unitOfWork.CommitAsync();
        }
    }
}
