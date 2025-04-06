using Ecommerce.Domain.UserAggregate;
using ECommerce.Infra.Data.Repositories.Base;

namespace ECommerce.Infra.Data.Repositories
{
    public class UserRepository(IUnitOfWork unitOfWork) : BaseRepository<UserDomain>(unitOfWork), IUserRepository
    {
    }
}
