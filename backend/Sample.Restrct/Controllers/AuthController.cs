using Microsoft.AspNetCore.Mvc;
using Sample.Restrct.Data.Entities;
using Sample.Restrct.Models;
using Sample.Restrct.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            var response=_authService.Login(user);
            if (!response.IsSuccess) {
                ModelState.AddModelError("message",response.Message);
                return View();
            }
            return View("Profile");
        }

    }
}
