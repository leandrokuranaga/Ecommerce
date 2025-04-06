using Ecommerce.Domain.SeedWork.Enums;
using Ecommerce.Domain.UserAggregate;
using System.Collections.Generic;

namespace ECommerce.Infra.Data.MapEntities.Seeds
{
    public static class UserSeed
    {
        public static List<UserDomain> Users()
        {
            return
            [
                new UserDomain
        {
            Id = 1,
            Name = "Admin",
            Email = "le.s.kuranaga@hotmail.com",
            Password = "$2a$11$GtOwXg2TwrUQJZJP0rfbDO93ZdUuDAE6RrfI8sFSa5Zq1/hXQ6CKq",
            Role = TypeUser.Admin
        },
        new UserDomain
        {
            Id = 2,
            Name = "Maria Souza",
            Email = "maria@email.com",
            Password = "$2a$11$YAXCibIjXzvDgcNq4xPPyOgTQ2m38qZx0uPCAUoS1skRtL3r8KRuG",
            Role = TypeUser.User
        }
            ];
        }
    }
}
