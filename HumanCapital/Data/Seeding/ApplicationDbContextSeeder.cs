using HumanCapital.Data.Common;
using HumanCapital.Models;
using Microsoft.AspNetCore.Identity;

namespace HumanCapital.Data.Seeding
{
    public static class ApplicationDbContextSeeder
    {
        public static void Seed(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            if (roleManager == null)
            {
                throw new ArgumentNullException(nameof(roleManager));
            }

            SeedRole(GlobalConstants.AdministratorRoleName, roleManager);
            SeedRole(GlobalConstants.RegularUserRoleName, roleManager);
        }

        private static void SeedRole(string roleName, RoleManager<ApplicationRole> roleManager)
        {
            var role = roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
            if (role == null)
            {
                var result = roleManager.CreateAsync(new ApplicationRole(roleName)).GetAwaiter().GetResult();

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
