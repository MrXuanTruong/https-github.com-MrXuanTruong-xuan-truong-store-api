using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class AvailableStockModel
    {
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public int Stock { get; set; }
        public long? LocalStock { get; set; }
        public long StockByColorId { get; set; }
        public long? ColorId { get; set; }
        public string ColorName { get; set; }
        public string Address { get; set; }
    }
}
