using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataTables.Queryable;
using Store.Entity.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using DataTables.AspNet.Core;
using AutoMapper;
using Store.API.Controllers;
using Store.Services;
using Store.API.Models;
using Store.API.Models.Operator;
using Store.Services.Helpers;
using Store.Entity.Criteria;
using Store.API.Models.Product;

namespace Store.Api.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        private object product;

        public ProductController(
            IProductService productService,
            IMapper mapper,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        // For Datatable
        [HttpGet("search")]
        public dynamic Search([FromQuery] ProductCriteriaModel criteria, [FromQuery] IDataTablesRequest request)
        {
            try
            {
                var query = _productService.GetAll();
                var products =
                    query
                    .Select(x => _mapper.Map<ProductItemModel>(x))
                    .ToList()
                    .AsQueryable();

                var filteredData = products;

                return ToDataTableResponse<ProductItemModel>(filteredData, request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.GetType().Name);
                return ToDataTableResponse<ProductItemModel>();
            }
        }
        

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpGet("{id:int}")]
        public async Task<ProductRequestModel> GetById(int id)
        {
            ProductRequestModel response;
            var product = await _productService.GetById(id);
            if (product != null)
            {
                response = new ProductRequestModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,
                    //Email = product.Email,
                    //Phone = product.Phone,
                };
            }
            else
            {
                response = new ProductRequestModel
                {
                };
            }

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel> Delete(int id)
        {
            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = await _productService.Detete(id);
            response.Messages.Add(response.Result ? SuccessMessage : FailMessage);

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPost]
        public async Task<ResponseViewModel> Save([FromBody] ProductRequestModel model)
        {
            var oldProduct =_productService.GetByProductName(model.ProductName);
            if (oldProduct != null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Tên sản phẩm đã tồn tại");

                return response;
            }
            else
            {
                var product = new Product
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    Stock = model.Stock,
                    //StatusId = model.StatusId,
                    ViewCount = model.ViewCount,
                    Description=model.Description,
                };
                return await SaveOrUpdate(product);
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel> Update(int id, [FromBody] ProductRequestModel model)
        {
            var oper = await _productService.GetById(id);
            if (oper == null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Không tìm thấy sản phẩm");

                return response;
            }

            oper.ProductName = model.ProductName;
            oper.Price = model.Price;
            oper.Stock = model.Stock;
            //StatusId = model.StatusId,
            oper.ViewCount = model.ViewCount;
            oper.Description = model.Description;
            //if (!string.IsNullOrEmpty(model.Password))
            //{
            //    oper.Password = Encryptor.MD5Hash(model.Password);
            //}
            return await SaveOrUpdate(oper);
        }

        private async Task<ResponseViewModel> SaveOrUpdate(Product product)
        {
            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = product.ProductId <= 0 ? await _productService.Insert(product) : await _productService.Update(product);
            if (response.Result == false)
            {
                response.Messages.Add($"Thao tác không thành công");
            }
            else
            {
                response.RefObjectId = product.ProductId;
            }

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        //[HttpGet("{id:int}/privileges")]
        //public async Task<IActionResult> GetPrivileges(int id)
        //{
        //    var response = new PrivilegeResponseModel
        //    {
        //        Result = true
        //    };

        //    var allPrivileges = parameter.OperatorBll.Privileges().ToList();
        //    var assignedPrivileges = await parameter.OperatorBll.PrivilegeOfOperator(id);

        //    response.Privileges = allPrivileges.Select(x => 
        //        new PrivilegeModel
        //        {
        //            PrivilegeId = x.PrivilegeId,
        //            PrivilegeName = x.PrivilegeName,
        //            Assigned = assignedPrivileges.Any(y => y.PrivilegeId == x.PrivilegeId)
        //        })
        //        .ToList();

        //    return Ok(response);
        //}

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        //[HttpPut("{id:int}/privileges")]
        //public async Task<IActionResult> UpdatePrivileges(int id, [FromBody] List<Privilege> privileges)
        //{
        //    var response = new PrivilegeResponseModel
        //    {
        //        Result = true
        //    };

        //    var assignedPrivileges = await parameter.OperatorBll.PrivilegeOfOperator(id);

        //    var removePrivileges = assignedPrivileges.Where(x => privileges.Any(y => y.PrivilegeId == x.PrivilegeId) == false).ToList();
        //    var addPrivileges = privileges.Where(x => assignedPrivileges.Any(y => y.PrivilegeId == x.PrivilegeId) == false).ToList();

        //    await parameter.OperatorBll.ApplyPrivilege(id, addPrivileges, removePrivileges);

        //    return Ok(response);
        //}
    }
}