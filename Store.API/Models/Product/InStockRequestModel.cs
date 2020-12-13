using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Store.API.Models.Product
{
    public class InStockRequestModel
    {
        public long BranchId { get; set; }
        public List<InStockColorModel> Details { get; set; }
        public string Note { get; set; }
    }
}
