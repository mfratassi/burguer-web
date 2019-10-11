using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace LanchesWeb.Data
{
    public static class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = { "Admin", "Member" };
            foreach (string role in roleNames)
            {
                var roleExists = roleManager.RoleExistsAsync(role).Result;
                if (!roleExists)
                {
                    IdentityResult roleIdentityResult = roleManager.CreateAsync(new IdentityRole(role)).Result;
                }
            }

            IdentityUser createdUser = new IdentityUser
            {
                UserName = configuration.GetSection("UserSettings")["UserName"],
                Email = configuration.GetSection("UserSettings")["UserEmail"],

            };

            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];

            IdentityUser checkUser = userManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]).Result;

            if (checkUser == null)
            {
                IdentityResult checkCreateUser = userManager.CreateAsync(createdUser, userPassword).Result;
                if (checkCreateUser.Succeeded)
                {
                    userManager.AddToRoleAsync(createdUser, "Admin").RunSynchronously();
                }
            }

        }

        public static void AddToRole(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = userManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]).Result;

            if (user != null)
            {
                IdentityResult ir = userManager.AddToRoleAsync(user, "Admin").Result;
                if (!ir.Succeeded)
                    throw new Exception("Erro");
            }
        }
    }
}
