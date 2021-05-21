using Challenge1.Entities;
using Challenge1.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signInManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;
        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public User AuthenticateUser(string UserName, string Password)
        {
            var result = _signInManager.PasswordSignInAsync(UserName, Password, false, false).Result;
            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(UserName).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();
                return user;
            }

            return null;
        }

        public IdentityResult CreateUser(User user, string Password)
        {
            var result = _userManager.CreateAsync(user, Password).Result;
            if (result.Succeeded)
            {
                string role = "User";
                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                    return res;
            }
            return result;
        }
        public IdentityResult UpdateUser(User model)
        {
            var res = _userManager.UpdateAsync(model).Result;
            return res;
        }
        public IdentityResult DeleteUser(User model)
        {
            var res = _userManager.DeleteAsync(model).Result;
            return res;
        }

        public User GetUser(string Id)
        {
            return _userManager.FindByIdAsync(Id).Result;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }
    }
}
