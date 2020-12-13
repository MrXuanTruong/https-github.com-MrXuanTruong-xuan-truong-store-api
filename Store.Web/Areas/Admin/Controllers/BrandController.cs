using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Services;
using Store.Web.Infrastructure;
using Store.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Store.Web.Controllers;

namespace Store.Web.Areas.Admin.Controllers
{
    public class BrandController : AdminBaseController
    {
        public BrandController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

    }
}