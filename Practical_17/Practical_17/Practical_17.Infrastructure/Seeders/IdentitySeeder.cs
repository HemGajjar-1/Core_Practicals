using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Practical_17.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_17.Infrastructure.Seeders
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            // ROLES

            if(!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if(!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            // DEFAULT ADMIN
            var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
            if(adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    FirstName = "System",
                    LastName = "Admin",
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    PhoneNumber = "9999999999",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
