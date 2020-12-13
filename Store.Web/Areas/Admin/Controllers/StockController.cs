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
    public class StockController : AdminBaseController
    {
        public StockController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public IActionResult InStock()
        {
            return View();
        }

        public IActionResult OutStock()
        {
            return View();
        }

        public IActionResult TransferStock()
        {
            return View();
        }

    }
}