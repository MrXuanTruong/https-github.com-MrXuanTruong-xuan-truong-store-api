using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.API.Controllers;
using Store.API.Models.Populate;
using Store.Services;

namespace Store.Api.Controllers
{
    [AllowAnonymous]
    public class PopulateController : AdminBaseController
    {
        private ICatagoryService _catagoryService;
        private readonly IMapper _mapper;
        public PopulateController(ICatagoryService catagoryService,
            IMapper mapper)
        {
            _catagoryService = catagoryService;
            _mapper = mapper;
        }

        [HttpGet("accountTypes")]
        public async Task<IList<AccountTypeItemModel>> AccountTypes()
        {
            var response = (await _catagoryService.AccountTypes())
                .Select( x => 
                    new AccountTypeItemModel
                    {
                        Id = x.AccountTypeId,
                        Name = x.AccountTypeName
                    })
                .ToList();

            return response;
        }

        [HttpGet("userStatuses")]
        public async Task<IList<AccountTypeItemModel>> AccountStatuses()
        {
            var response = (await _catagoryService.AccountTypes())
                .Select(x =>
                   new AccountTypeItemModel
                   {
                       Id = x.AccountTypeId,
                       Name = x.AccountTypeName
                   })
                .ToList();

            return response;
        }
    }
}
