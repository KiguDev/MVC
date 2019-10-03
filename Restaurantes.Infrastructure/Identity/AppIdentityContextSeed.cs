using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantes.Infrastructure.Identity
{
    public static class AppIdentityContextSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(Role));
            foreach(var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            var defaultUser = new IdentityUser
            {
                UserName = "ernesto@admin.com",
                Email = "ernesto@admin.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(defaultUser, "Admin_123");
            await userManager.AddToRoleAsync(defaultUser, Role.Administrator.ToString());

        }
    }
}
