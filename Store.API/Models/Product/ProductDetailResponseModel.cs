using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class ProductDetailResponseModel
    {
        public long? Id { get; set; }
        public long ProductId { get; set; }
        public long ProductImageId { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ProductName { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public long? ProductBrandId { get; set; }
        public string ProductBrandName { get; set; }
        public List<ProductColorModel> ProductColors { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ViewCount { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public long? ProductStatusId { get; set; }
        public string ProductStatusName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public List<Branch> StoreAvailables { get; set; }
        public List<ProductImageModel> Images { get; set; }
    }
}
