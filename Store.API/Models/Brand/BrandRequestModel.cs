using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Brand
{
    public class BrandRequestModel
    {
        //public long ProductBrandId { get; set; }
       
        //public string ProductBrandName { get; set; }
        public long Id { get; set; }
        public string BrandName { get; set; }
    }
}
