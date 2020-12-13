using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class ProductImageModel
    {
        public long ProductImageId { get; set; }

        public string ProductImageUrl { get; set; }

        public long? ProductId { get; set; }
    }
}
