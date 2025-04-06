namespace ECommerce.Infra.Data
{
    public class UnitOfWork(Context context) : IUnitOfWork
    {
        public Context Context { get; set; } = context;

        public async Task CommitAsync()
        {
            using var transaction = await this.Context.Database.BeginTransactionAsync();
            try
            {
                await this.Context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
