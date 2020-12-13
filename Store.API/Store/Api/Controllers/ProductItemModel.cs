using System;
using System.Collections.Generic;

namespace Store.Api.Controllers
{
    public class ProductItemModel
    {
        public long? Id { get; set; }
        public string ProductName { get; set; }
        public long? ProductImageId { get; set; }
        public long? CategoryId { get; set; }
        public long? ProductBrandId { get; set; }
        public long? ProductColorId { get; set; }
        public long? ColorId { get; set; }
        public long? ProductStatusId { get; set; }
        public long? ProductBranchId { get; set; }
        public string ProductImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string ProductBrandName { get; set; }
        public string ColorName { get; set; }
        public string ProductStatusName { get; set; }
        public string ProductBranchName { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public int ViewCount { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; internal set; }
        public List<string> ColorNames { get; set; }
        public List<string> BranchNames { get; set; }
        public List<string> ProductImageUrls { get; set; }

    }
}