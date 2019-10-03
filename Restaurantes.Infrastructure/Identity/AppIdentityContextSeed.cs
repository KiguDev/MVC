using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Restaurantes.Infrastructure.Identity
{
    public class AppIdentityContextSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser>
            usermanager,RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(Role));
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            var defaultUser = new IdentityUser
            {
                UserName = "alfavenegas@admin.com",
                Email = "alfavenegas@admin.com",
                EmailConfirmed = true
            };

            await usermanager.CreateAsync(defaultUser, "Admin123.");
            await usermanager.AddToRoleAsync(defaultUser,
                Role.Administrator.ToString());
        }
    }
}
