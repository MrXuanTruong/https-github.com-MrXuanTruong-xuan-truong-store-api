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
    public class OperatorController : AdminBaseController
    {
        public OperatorController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public IActionResult Index(int? accountTypeId = null)
        {
            var model = new OperatorIndexModel
            {
                AccountTypeId = accountTypeId
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new EditActionModel
            {
                Id = id
            };

            return View(model);
        }
    }
}