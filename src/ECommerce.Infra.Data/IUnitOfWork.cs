namespace ECommerce.Infra.Data
{
    public interface IUnitOfWork
    {
        Context Context { get; }
        Task CommitAsync();
    }
}
