using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;
using Store.Services;
using Store.Web.Infrastructure;
using Store.Services.Extentions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Store.Web.Controllers
{
    public class AccountController : FontEndBaseController
    {
        public AccountController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
    }
}
