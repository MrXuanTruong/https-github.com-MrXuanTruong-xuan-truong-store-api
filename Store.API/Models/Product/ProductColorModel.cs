using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class ProductColorModel
    {
        public long ProductColorId { get; set; }

        public long? ProductId { get; set; } // 1 | 1

        public long ColorId { get; set; } // 1 | 1

        public double Price { get; set; }

        public string ColorName { get; set; }
    }
}
