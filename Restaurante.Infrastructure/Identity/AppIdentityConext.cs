
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Infrastructure.Identity
{
    public class AppIdentityContext: IdentityDbContext
    {
        public AppIdentityContext(DbContextOptions<AppIdentityContext> options): base (options)
        {
            
        }
    }
}
