using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Models
{
    /// <summary>
    /// This model is for response from the end point.
    /// </summary>
    public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
    }
}
