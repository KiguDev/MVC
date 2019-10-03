using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Restaurantes.Infrastructure.Identity
{
    public class AppIdentityContext : IdentityDbContext
    {
       public AppIdentityContext(DbContextOptions<AppIdentityContext> options)
            : base (options)
        {

        }
    }
}
