﻿using System;
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
        private readonly IOrderService _orderService;
        
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        //private object product;

        public ProductController(
            IProductService productService,
            IOrderService orderService,
            IMapper mapper,
            ILogger<ProductController> logger)
        {
            _productService = productService;
            _orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        // For Datatable
        [HttpGet("GetList")]
        public dynamic GetList([FromQuery] ProductCriteriaModel criteria, [FromQuery] IDataTablesRequest request)
        {
            try
            {

                var query = _productService.GetAll();
                var products =
                    query
                    .Select(x => new ProductItemModel
                    {
                        Id = x.ProductId,
                        ProductName = x.ProductName,
                        ProductImageUrl = x.ThumnailUrl,
                        CategoryId = x.CategoryId,
                        CategoryName = x.Category.CategoryName,
                        ProductBrandName = x.ProductBrand.ProductBrandName,
                        ColorNames = x.ProductColors.Select(x => x.Color.ColorName).ToList(),
                        BranchNames = x.ProductBranchs.Select(x => x.Branch.BranchName).ToList(),
                        ProductStatusId = x.ProductStatusId,
                        ProductStatusName = x.ProductStatus.ProductStatusName,
                        Price = x.Price,
                        Stock = x.Stock,
                        ViewCount = x.ViewCount,
                        Description = x.Description,
                        CreatedDate = DateTime.UtcNow,
                    })
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

        //api/product/id
        [HttpGet("{id:int}")]
        public async Task<ProductRequestModel> GetById(int id)
        {
            ProductRequestModel response;
            var product = await _productService.GetById(id);
            if (product != null)
            {
                response = new ProductRequestModel
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName,
                    ThumnailUrl = product.ThumnailUrl,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    ProductBrandId = product.ProductBrandId,
                    ProductBrandName = product.ProductBrand.ProductBrandName,
                    ProductStatusId = product.ProductStatusId,
                    ProductStatusName = product.ProductStatus.ProductStatusName,
                    Price = product.Price,
                    Stock = product.Stock,
                    ViewCount = product.ViewCount,
                    Description = product.Description,
                    ProductColors = product.ProductColors
                        .Select(x => new ProductColorModel
                        {
                            ColorId = x.ColorId,
                            ColorName = x.Color.ColorName,
                            Price = x.Price,
                            ProductColorId = x.ProductColorId,
                            ProductId = x.ProductId,
                        })
                        .ToList(),
                };

                if(product.ProductImages != null)
                {
                    response.SliderImages = product.ProductImages
                        .Select(x => x.ProductImageUrl)
                        .ToList();
                }
                else
                {
                    response.SliderImages = new List<string>();
                }

                if (product.ProductBranchs != null)
                {
                    response.AvailableStocks = product.ProductBranchs
                        .GroupBy(l => l.BranchId)
                        .Select(x => new AvailableStockModel
                        {
                            BranchId = x.First().BranchId,
                            BranchName = x.First().Branch.BranchName,
                            Stock = x.Sum(c => c.LocalStock).GetValueOrDefault()
                        })
                        .ToList();
                }
                else
                {
                    response.AvailableStocks = new List<AvailableStockModel>();
                }
            }
            else
            {
                response = new ProductRequestModel
                {
                    Id = 0,
                    ProductColors = new List<ProductColorModel>()
                    {
                        new ProductColorModel { },
                    },
                    AvailableStocks = new List<AvailableStockModel>(),
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
            var product = new Product
            {
                ProductName = model.ProductName,
                Price = model.Price,
                CategoryId = model.CategoryId,
                ProductBrandId = model.ProductBrandId,
                ThumnailUrl = model.ThumnailUrl,
                ProductStatusId = model.ProductStatusId,
                Description = model.Description,
                Stock = 0,
                ProductColors = model.ProductColors
                .Select(x => new ProductColor
                {
                    ColorId = x.ColorId,
                    Price = x.Price,
                    ProductColorId = x.ProductColorId,
                    ProductId = x.ProductId,
                }).ToList(),

            };

            if (model.SliderImages != null)
            {
                product.ProductImages = model.SliderImages.Select(x =>
                new ProductImage
                {
                    ProductId = product.ProductId,
                    ProductImageUrl = x,
                }).ToList();
            }
            else
            {
                product.ProductImages = new List<ProductImage>();
            }

            return await SaveOrUpdate(product);
        }

        //[Authorize(Roles = PermissionConstant.MANAGE_OPERATOR)]
        [HttpPut("{id:int}")]
        public async Task<ResponseViewModel> Update(int id, [FromBody] ProductRequestModel model)
        {
            var product = await _productService.GetByIdWithoutInclude(id);
            if (product == null)
            {
                var response = new ResponseViewModel
                {
                    Result = false,
                };

                response.Messages.Add("Không tìm thấy sản phẩm");

                return response;
            }

            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.ProductBrandId = model.ProductBrandId;
            //oper.ProductColorId = model.ProductColorId;
            product.ProductStatusId = model.ProductStatusId;
            product.ThumnailUrl = model.ThumnailUrl;
            product.Description = model.Description;

            product.ProductColors = model.ProductColors
                .Select(x => new ProductColor
                {
                    ColorId = x.ColorId,
                    Price = x.Price,
                    ProductColorId = x.ProductColorId,
                    ProductId = x.ProductId,
                }).ToList();

            product.ProductImages = model.SliderImages.Select(x =>
            new ProductImage
            {
                ProductId = product.ProductId,
                ProductImageUrl = x,
            }).ToList();


            return await SaveOrUpdate(product);
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

        [AllowAnonymous]
        [HttpGet("newestProducts")]
        public List<ProductRequestModel> NewestProducts()
        {
            var products = _productService.NewestProducts(10);
            var response =
                products.Select(x =>
                new ProductRequestModel
                {
                    Id = x.ProductId,
                    ProductName = x.ProductName,
                    ThumnailUrl = x.ThumnailUrl,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.CategoryName,
                    ProductBrandName = x.ProductBrand.ProductBrandName,
                    ProductStatusId = x.ProductStatusId,
                    ProductStatusName = x.ProductStatus.ProductStatusName,
                    Price = x.Price,
                    Stock = x.Stock,
                    ViewCount = x.ViewCount,
                    Description = x.Description,
                    ProductColors = x.ProductColors.Select(x => new ProductColorModel
                    {
                        ColorId = x.ColorId,
                        ColorName = x.Color.ColorName,
                        Price = x.Price,
                        ProductColorId = x.ProductColorId,
                        ProductId = x.ProductId,
                    })
                        .ToList()

                })
                .ToList();

            return response;
        }

        [AllowAnonymous]
        [HttpGet("featureProducts")]
        public List<ProductRequestModel> FeatureProducts()
        {
            var products = _productService.FeatureProducts(10);
            var response =
                products.Select(x =>
                new ProductRequestModel
                {
                    Id = x.ProductId,
                    ProductName = x.ProductName,
                    ThumnailUrl = x.ThumnailUrl,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.CategoryName,
                    ProductBrandName = x.ProductBrand.ProductBrandName,
                    ProductStatusId = x.ProductStatusId,
                    ProductStatusName = x.ProductStatus.ProductStatusName,
                    Price = x.Price,
                    Stock = x.Stock,
                    ViewCount = x.ViewCount,
                    Description = x.Description,
                    ProductColors = x.ProductColors.Select(x => new ProductColorModel
                    {
                        ColorId = x.ColorId,
                        ColorName = x.Color.ColorName,
                        Price = x.Price,
                        ProductColorId = x.ProductColorId,
                        ProductId = x.ProductId,
                    })
                        .ToList()

                })
                .ToList();

            return response;
        }

        [HttpPost("inStocks")]
        public async Task<ResponseViewModel> InStocks([FromBody] InStockRequestModel model)
        {
            var instocks = await _productService.InStocks(
                model.BranchId,
                model.Note,
                model.Details.Select(x => x.ProductId).ToList(),
                model.Details.Select(x => x.ColorId).ToList(),
                model.Details.Select(x => x.Quantity).ToList(),
                model.Details.Select(x => x.Price).ToList());

            var response = new ResponseViewModel
            {
                Result = true,
            };

            response.Result = instocks;
            if (response.Result == false)
            {
                response.Messages.Add($"Thao tác không thành công");
            }
            else
            {
                response.Messages.Add($"Thao tác thành công");
            }

            return response;
        }

        [HttpPost("outStocks")]
        public async Task<ResponseViewModel> OutStocks(long orderId)
        {
            var response = new ResponseViewModel
            {
                Result = false,
            };

            var order = await _orderService.GetById(orderId);
            if(order == null)
            {
                response.Messages.Add($"Đơn hàng không tồn tại");
            }
            else if(order.OrderStatusId != 2)
            {
                response.Messages.Add($"Đơn hàng không cho phép xuất kho");
            }
            else if (order.BranchId == null)
            {
                response.Messages.Add($"Đơn hàng không không xác định được kho để xuất");
            }
            else if (order.OrderDetails.Any(x => x.ColorId == null))
            {
                response.Messages.Add($"Đơn hàng Có sản phẩm chưa chọn màu sắc");
            }
            else 
            {
                var outstocks = await _productService.OutStocks(
                    order.BranchId.GetValueOrDefault(),
                    order.OrderId,
                    "",
                    order.OrderDetails.Select(x => x.ProductId).ToList(),
                    order.OrderDetails.Select(x => x.ColorId).ToList(),
                    order.OrderDetails.Select(x => x.Quantity).ToList(),
                    order.OrderDetails.Select(x => x.Price).ToList());

                response.Result = outstocks;
                if (response.Result == false)
                {
                    response.Messages.Add($"Thao tác không thành công");
                }
                else
                {
                    // Update trạng thái Đơn hàng sang xuất kho.
                    order.OrderStatusId = 4;
                    await _orderService.Update(order);

                    response.Messages.Add($"Thao tác thành công");
                }
            }
            

            return response;
        }

        //Tạm thoi che nó lai de chay dc tính năng kia

        //[HttpPost("tranferStock")]
        //public async Task<ResponseViewModel> TranferStock([FromBody] OutStockRequestModel model)
        //{
        //    var outstocks = await _productService.OutStocks(
        //        model.OrderId,
        //        model.ExportStockCode,
        //        model.Note,
        //        model.Details.Select(x => x.ProductId).ToList(),
        //        model.Details.Select(x => x.ColorId).ToList(),
        //        model.Details.Select(x => x.Quantity).ToList(),
        //        model.Details.Select(x => x.Price).ToList());

        //    var response = new ResponseViewModel
        //    {
        //        Result = true,
        //    };

        //    response.Result = outstocks;
        //    if (response.Result == false)
        //    {
        //        response.Messages.Add($"Thao tác không thành công");
        //    }
        //    else
        //    {
        //        response.Messages.Add($"Thao tác thành công");
        //    }

        //    return response;
        //}

        [AllowAnonymous]
        [HttpGet("productDetail")]
        public async Task<ProductDetailResponseModel> ProductDetail(long id)
        {
            ProductDetailResponseModel response = null;
            var productTask = _productService.GetById(id);

            var product = await productTask;

            if (product != null)
            {
                response = new ProductDetailResponseModel
                {
                    Id = product.ProductId,
                    ProductName = product.ProductName,
                    ThumbnailUrl = product.ThumnailUrl,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    ProductBrandName = product.ProductBrand.ProductBrandName,
                    ProductStatusId = product.ProductStatusId,
                    ProductStatusName = product.ProductStatus.ProductStatusName,
                    Price = product.Price,
                    Stock = product.Stock,
                    ViewCount = product.ViewCount,
                    Description = product.Description,
                };
                response.ProductColors = product.ProductColors
                    .Select(x => new ProductColorModel
                    {
                        ColorId = x.ColorId,
                        ColorName = x.Color.ColorName,
                        Price = x.Price,
                        ProductColorId = x.ProductColorId,
                        ProductId = x.ProductId,
                    })
                    .ToList();
                var storeAvailableTask = _productService.GetStoreAvailableForProductId(id);
                response.StoreAvailables = await storeAvailableTask;

                var productImagesTask = _productService.GetImagesForProductId(id);

                response.Images = (await productImagesTask)
                    .Select(x => new ProductImageModel
                    {
                        ProductImageId = x.ProductImageId,
                        ProductImageUrl = x.ProductImageUrl,
                        ProductId = x.ProductId,
                    })
                    .ToList();
            }

            return response;
        }



    }
}