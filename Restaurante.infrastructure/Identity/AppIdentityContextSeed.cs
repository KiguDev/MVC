using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.infrastructure.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(Role));

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            var defaultUser = new IdentityUser
            {
                UserName = "antonio@integon.com",
                Email = "antonio@integon.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(defaultUser,"Admin123.");
            await userManager.AddToRoleAsync(defaultUser, Role.Administrator.ToString());
        }
    }
}
