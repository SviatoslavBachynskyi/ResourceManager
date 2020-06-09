using Microsoft.AspNetCore.Identity;
using ResourceManager.Core.Models;
using ResourceManager.Dal;
using System.Threading.Tasks;

namespace ResourceManager.Core
{
    public static class DataSeeder
    {
        public static async Task SeedEssentialDataAsync
            (
            ResourceManagerContext context,
            UserManager<Worker> userManager,
            RoleManager<IdentityRole> roleManager,
            string adminPassword
            )
        {
            await SeedRolesAsync(roleManager);
            await CreateAdmin(userManager, adminPassword);
            await context.SaveChangesAsync();
        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await CreateRoleIfNotExistsAsync(roleManager, new IdentityRole(Role.Admin.ToString()));
            await CreateRoleIfNotExistsAsync(roleManager, new IdentityRole(Role.Manager.ToString()));
            await CreateRoleIfNotExistsAsync(roleManager, new IdentityRole(Role.InventoryManager.ToString()));
            await CreateRoleIfNotExistsAsync(roleManager, new IdentityRole(Role.Worker.ToString()));
        }

        private static async Task CreateRoleIfNotExistsAsync(RoleManager<IdentityRole> roleManager, IdentityRole role)
        {
            if (await roleManager.FindByNameAsync(role.Name) == null)
            {
                await roleManager.CreateAsync(role);
            }
        }

        private static async Task CreateAdmin(UserManager<Worker> userManager, string adminPassword)
        {
            var user = new Worker() { 
                UserName = "Admin", 
                Email="Admin@test.com",
                EmailConfirmed = true,
                FirstName="Admin",
            FatherName="Admin",
            LastName="Admin",
            CityId = 1,
            PostId = 1};

            if (await userManager.FindByNameAsync(user.UserName) != null)
                return;

            var createResult = await userManager.CreateAsync(user, adminPassword);

            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Role.Admin.ToString());
            }
        }

    }
}
