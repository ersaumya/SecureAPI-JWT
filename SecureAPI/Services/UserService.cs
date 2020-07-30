using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SecureAPI.Constant;
using SecureAPI.Models;
using SecureAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Jwt _jwt;
        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<Jwt> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<string> RegisterAsync(Register registerModel)
        {
            var user = new ApplicationUser
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                UserName = registerModel.Username,
                Email = registerModel.Email
            };
            var userEmailExists = await _userManager.FindByEmailAsync(registerModel.Email);
            if(userEmailExists == null)
            {
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Authorize.default_role.ToString());
                }
                return $"User succesfully registered with username {user.UserName} ";
            }
            else
            {
                return $"Email {user.Email} is already registered.";
            }
        }
    }
}
