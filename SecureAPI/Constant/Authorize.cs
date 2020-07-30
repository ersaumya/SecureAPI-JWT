using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureAPI.Constant
{
    public class Authorize    {
        public enum Roles
        {
            Admin,
            User,
            Guest
        }
        public const string default_username = "soumya";
        public const string default_email = "ersaumyarout@gmail.com";
        public const string default_password = "Rout@123";
        public const Roles default_role = Roles.Admin;
    }
}
