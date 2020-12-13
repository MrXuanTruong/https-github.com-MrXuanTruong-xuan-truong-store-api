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
    }
}
