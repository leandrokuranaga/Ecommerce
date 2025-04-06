using Ecommerce.Domain.ProductAggregate;

namespace Ecommerce.Application.Commands.Product
{
    public class DeleteProductCommandHandler(IProductRepository repository)
    {
        public async Task<bool> Handle(int id)
        {
            var product = await repository.GetByIdAsync(id, false);
            if (product == null)
                return false;

            await repository.DeleteAsync(product);
            return true;
        }
    }
}
