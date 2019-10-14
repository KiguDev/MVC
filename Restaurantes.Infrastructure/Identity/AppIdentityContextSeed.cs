using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantes.Infrastructure.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedASync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(Role));

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));

            }

            var defaultUser = new IdentityUser
            {
                UserName = "jemmyPC",
                Email = "preciadojemmy@gmail.com",
                EmailConfirmed = true,
                
            };

            await userManager.CreateAsync(defaultUser, "Paste.l19"); 
            await userManager.AddToRoleAsync(defaultUser, Role.Administrator.ToString());
        }
    }
}