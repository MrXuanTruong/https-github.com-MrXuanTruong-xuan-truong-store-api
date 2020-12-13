using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class InStockColorModel
    {
        public long ProductId { get; set; }
        public long ColorId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
