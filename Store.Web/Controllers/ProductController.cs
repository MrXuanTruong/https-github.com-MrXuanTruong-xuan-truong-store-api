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

namespace Store.Web.Controllers
{
    public class ProductController : FontEndBaseController
    {
        public ProductController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public IActionResult Detail(long id)
        {
            var model = new EditActionModel
            {
                Id = id
            };

            return View(model);
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult Order(long id)
        {
            var model = new EditActionModel
            {
                Id = id
            };

            return View(model);
        }
    }
}
