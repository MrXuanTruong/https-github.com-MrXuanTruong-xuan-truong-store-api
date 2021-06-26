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
using Store.API.Models.Brand;

namespace Store.Api.Controllers
{
    public class BrandController : AdminBaseController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly ILogger<BrandController> _logger;
        public BrandController(
            IBrandService brandService,
            IMapper mapper,
            ILogger<BrandController> logger)
        {
            _brandService = brandService;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        // For Datatable
        [HttpGet("GetList")]
        public dynamic GetList([FromQuery] API.Models.Brand.BrandCriteriaModel criteria, [FromQuery] IDataTablesRequest request)
        {
            try
            {
                //var query = _accountService.GetByCriteria(criteria);
                var query = _brandService.GetAll();
                var brands =
                    query
                    .Select(x => new API.Models.Brand.BrandCriteriaModel
                    {
                        Id = x.ProductBrandId,
                        BrandName = x.ProductBrandName,

                    })
                    .ToList()
                    .AsQueryable();

                var filteredData = brands;

                return ToDataTableResponse<API.Models.Brand.BrandCriteriaModel>(filteredData, request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.GetType().Name);
                return ToDataTableResponse<API.Models.Brand.BrandCriteriaModel>();
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpGet("{id:int}")]
        public async Task<API.Models.Brand.BrandCriteriaModel> GetById(int id)
        {
            API.Models.Brand.BrandCriteriaModel response;
            var brand = await _brandService.GetById(id);
            if (brand != null)
            {
                response = new API.Models.Brand.BrandCriteriaModel
                {
                    Id = brand.ProductBrandId,
                    BrandName = brand.ProductBrandName,
                };
            }
            else
            {
                response = new API.Models.Brand.BrandCriteriaModel
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

            response.Result = await _brandService.Detete(id);
            response.Messages.Add(response.Result ? SuccessMessage : FailMessage);

            return response;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPost]
        public async Task<ResponseViewModel> Create(int id,[FromBody] API.Models.Brand.BrandCriteriaModel model)
        {
            //var oldBrand = await _brandService.GetByIdWithoutInclude(model.GetByIdWithoutInclude);
            var oldBrand = await _brandService.GetById(id);
            if (oldBrand != null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Tên nhãn hiệu đã tồn tại");

                return response;
            }
            else
            {
                var productBrand = new ProductBrand
                {
                    ProductBrandName = model.BrandName,
                    
                };

                ApplyUserCreateEntity(productBrand);

                return await SaveOrUpdate(productBrand);
            }
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel> Update(int id, [FromBody] API.Models.Brand.BrandCriteriaModel model)
        {
            var oper = await _brandService.GetById(id);
            if (oper == null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Không tìm thấy nhãn hiệu");

                return response;
            }

            oper.ProductBrandName = model.BrandName;
            
            ApplyUserUpdateEntity(oper);

            return await SaveOrUpdate(oper);
        }

        private async Task<ResponseViewModel> SaveOrUpdate(ProductBrand productBrand)
        {
            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = productBrand.ProductBrandId <= 0 ? await _brandService.Insert(productBrand) : await _brandService.Update(productBrand);
            if (response.Result == false)
            {
                response.Messages.Add($"Thao tác không thành công");
            }
            else
            {
                response.RefObjectId = productBrand.ProductBrandId;
            }

            return response;
        }

        
    }
}