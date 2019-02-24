using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.code;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Operations
{
    public interface IAccountOperations
    {
        Task<LoginInfoViewModel> Login(LoginViewModel model);
        Task Logout();
    }

    internal class AccountOperations : IAccountOperations
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountOperations(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginInfoViewModel> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

            if (!result.Succeeded) throw new UnauthorizedAccessException("Could not login");

            var appUser = _userManager.Users.Single(r => r.UserName == model.Username);

            var loginResult = new LoginInfoViewModel
            {
                UserId = appUser.Id,
                Token = JwtService.GenerateJwtToken(_configuration, model.Username, appUser),
            };

            return loginResult;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
