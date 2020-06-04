using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Infrastructure.Data
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            // Skip if db has been seeded
            if (context.Users.Any())
            {
                return;
            }

            // Create default administrator
            var defaultUser = new ApplicationUser {
                UserName = "admin@localhost", 
                Email = "admin@localhost.com",
                EmailConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, "admin@localHost.1");
            }

            await context.SaveChangesAsync();
        }
    }
}