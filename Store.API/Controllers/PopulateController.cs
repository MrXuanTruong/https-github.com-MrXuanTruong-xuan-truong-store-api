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
using Store.Entity.Enums;
using Store.Services;

namespace Store.Api.Controllers
{
    [AllowAnonymous]
    public class PopulateController : AdminBaseController
    {
        private IAccountService _accountService;
        private ICatagoryService _catagoryService;
        private IProductService _productService;
        private readonly IMapper _mapper;
        public PopulateController(
            ICatagoryService catagoryService, 
            IProductService productService,
            IAccountService accountService,
        IMapper mapper)
        {
            _catagoryService = catagoryService;
            _productService = productService;
            _mapper = mapper;
            _accountService = accountService;
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
            var response = (await _catagoryService.AccountStatuses())
                .Select(x =>
                   new AccountTypeItemModel
                   {
                       Id = x.AccountStatusId,
                       Name = x.AccountStatusName
                   })
                .ToList();

            return response;
        }

        [HttpGet("branches")]
        public async Task<IList<AccountTypeItemModel>> Branches()
        {
            var response = (await _catagoryService.Branches())
                .Select(x =>
                   new AccountTypeItemModel
                   {
                       Id = x.BranchId,
                       Name = x.BranchName
                   })
                .ToList();

            return response;
        }

        [HttpGet("productStatuses")]
        public async Task<List<ProductStatusItemModel>/*Output*/> GetProductStatuses(/*input*/)
        {
            var listProductStatuses = await _catagoryService.ProductStatuses();
            var response =
                listProductStatuses
                .Select(x =>
                   new ProductStatusItemModel
                   {
                       Id = x.ProductStatusId,
                       Name = x.ProductStatusName
                   })
                .ToList();

            return response;
        }

        [HttpGet("productCategories")]
        public async Task<List<CategoryItemModel>/*Output*/> productCategories(/*input*/)
        {
            var listCategories = await _catagoryService.Categories();
            var response =
                listCategories
                .Select(x =>
                   new CategoryItemModel
                   {
                       Id = x.CategoryId,
                       Name = x.CategoryName
                   })
                .ToList();

            return response;
        }

        [HttpGet("productBrands")]
        public async Task<List<BrandItemModel>/*Output*/> productBrands(/*input*/)
        {
            var listBrands = await _catagoryService.Brands();
            var response =
                listBrands
                .Select(x =>
                   new BrandItemModel
                   {
                       Id = x.ProductBrandId,
                       Name = x.ProductBrandName
                   })
                .ToList();

            return response;
        }
        [HttpGet("colorsByProductId")]
        public async Task<List<ColorItemModel>> ColorsByProductId(long productId)
        {
            var listProductColors = await _catagoryService.ColorsByProductId(productId);
            var response =
                listProductColors
                .Select(x =>
                   new ColorItemModel
                   {
                       Id = x.ColorId,
                       Name = x.Color.ColorName
                   })
                .ToList();

            return response;
        }


        [HttpGet("colors")]
        public async Task<List<ColorItemModel>/*Output*/> Colors(/*input*/)
        {
            var listColors = await _catagoryService.Colors();
            var response =
                listColors
                .Select(x =>
                   new ColorItemModel
                   {
                       Id = x.ColorId,
                       Name = x.ColorName
                   })
                .ToList();

            return response;
        }

        [HttpGet("products")]
        public List<ProductItemModel> Products()
        {
            var listProducts = _productService.GetAll();
            var response =
                listProducts
                .Select(x =>
                   new ProductItemModel
                   {
                       Id = x.ProductId,
                       ProductName = x.ProductName
                   })
                .ToList();

            return response;
        }

        [HttpGet("orderStatuses")]
        public async Task<List<OrderStatusItemModel>> GetOrderStatuses()
        {
            var listOrderStatuses = await _catagoryService.OrderStatuses();
            var response =
                listOrderStatuses
                .Select(x =>
                   new OrderStatusItemModel
                   {
                       Id = x.OrderStatusId,
                       Name = x.OrderStatusName
                   })
                .ToList();

            return response;
        }

        [HttpGet("orderConfirmeds")]
        public async Task<List<OrderItemModel>> GetOrderConfirmeds()
        {
            var listOrderStatuses = await _catagoryService.GetOrderConfirmeds();
            var response =
                listOrderStatuses
                .Select(x =>
                   new OrderItemModel
                   {
                       OrderId = x.OrderId,
                       OrderCode = x.OrderCode
                   })
                .ToList();

            return response;
        }

        [HttpGet("orderPaids")]
        public async Task<List<OrderItemModel>> GetOrderPaids()
        {
            var listOrderStatuses = await _catagoryService.GetOrderPaids();
            var response =
                listOrderStatuses
                .Select(x =>
                   new OrderItemModel
                   {
                       OrderId = x.OrderId,
                       OrderCode = x.OrderCode
                   })
                .ToList();

            return response;
        }


        [HttpGet("accounts")]
        public async Task<IList<AccountItemModel>> Accounts()
        {
            var response = _accountService.GetAll().Where(x => x.AccountTypeId == AccountTypeEnum.Customer)
                .Select(x =>
                   new AccountItemModel
                   {
                       Id = x.AccountId,
                       Name = $"{x.FullName} ({x.Phone})"
                   })
                .ToList();

            return response;
        }

    }
}
