using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Product
{
    public class ProductBranchModel
    {
        public long ProductBranchId { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public int? LocalStock { get; set; }
        public long? ProductId { get; set; }
        public long? ColorId { get; set; }
    }
}
