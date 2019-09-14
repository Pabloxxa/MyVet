using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyVet.Web.Data.Entities;
using MyVet.Web.Models;

namespace MyVet.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        public readonly UserManager<User> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly SignInManager<User> _signInManager;

        public UserHelper(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task AddUserToRoleAsync(User user, string roleName)
        {
            return _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await CreateRoleAsync(roleName);
            }
        }

        private async Task CreateRoleAsync(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = roleName
            });
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe, 
                false);
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
