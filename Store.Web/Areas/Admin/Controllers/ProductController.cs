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
    public class ProductController : AdminBaseController
    {
        public ProductController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            var model = new AddActionModel
            {
                Id = id
            };

            return View(model);
        }
    }
}