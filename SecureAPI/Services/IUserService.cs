using SecureAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(Register registerModel);
        Task<AuthenticationModel> GetTokenAsync(TokenRequest tokenRequest);
        Task<string> AddRoleAsync(AddRole model);
        Task<AuthenticationModel> RefreshTokenAsync(string token);
    }
}
