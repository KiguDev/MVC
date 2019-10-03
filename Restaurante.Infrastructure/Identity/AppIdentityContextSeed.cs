using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedASync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(Role));

            foreach(var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            var defaultuser = new IdentityUser
            {
                UserName = "alex@eladmin.com",
                Email = "alex@eladmin.com",
                EmailConfirmed = true,
            };

            await userManager.CreateAsync(defaultuser, "Admin123.");
            await userManager.AddToRoleAsync(defaultuser, Role.Administrator.ToString());
        }
    }
}
