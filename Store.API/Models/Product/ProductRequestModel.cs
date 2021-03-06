﻿using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class ProductRequestModel
    {
        public long? Id { get; set; }
        public long ProductId { get; set; }
        public long ProductImageId { get; set; }
        public string ThumnailUrl { get; set; }
        
        public string ProductName { get; set; }
        
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long? ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }
        public List<ProductColorModel> ProductColors { get; set; }
        public List<string> SliderImages { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ViewCount { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public long? ProductStatusId { get; set; }
        public string ProductStatusName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ProductBranchModel> GetProductBranches { get; set; }
        
        public List<AvailableStockModel> AvailableStocks { get; set; }
    }
}
