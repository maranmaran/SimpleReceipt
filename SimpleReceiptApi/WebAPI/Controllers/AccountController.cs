using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Operations;
using ServiceLayer.ViewModels;

namespace Website.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IApplicationUserOperations _applicationUserOperations;
        private readonly IAccountOperations _accountOperations;


        public AccountController(
            IAccountOperations accountOperations,
            IApplicationUserOperations applicationUserOperations)
        {
            _accountOperations = accountOperations;
            _applicationUserOperations = applicationUserOperations;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = await _accountOperations.Login(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _accountOperations.Logout();
            return Ok(true);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllWaiters(long id)
        {
            var result = await _applicationUserOperations.GetAllWaitersByCafeId(id);
            return Ok(result);
        }
    }
}