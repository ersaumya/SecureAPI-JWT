
using Microsoft.AspNetCore.Identity;
using SecureAPI.Models;
using SecureAPI.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SecureAPI.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Authorize.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorize.Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorize.Roles.Guest.ToString()));
            //Seed Default User
            var defaultUser = new ApplicationUser { UserName = Authorize.default_username, Email = Authorize.default_email, EmailConfirmed = true, PhoneNumberConfirmed = true };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, Authorize.default_password);
                await userManager.AddToRoleAsync(defaultUser, Authorize.default_role.ToString());
            }
        }
    }
}
