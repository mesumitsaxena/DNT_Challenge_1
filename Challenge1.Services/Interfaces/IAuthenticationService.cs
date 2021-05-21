using Challenge1.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Services.Interfaces
{
    public interface IAuthenticationService
    {
        IdentityResult CreateUser(User user, string Password);
        User AuthenticateUser(String UserName, string Password);
        User GetUser(string Id);
        IEnumerable<User> GetAllUsers();
        IdentityResult UpdateUser(User model);
        IdentityResult DeleteUser(User model);

    }
}
