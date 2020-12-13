using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductStatuses")]
    public class ProductStatus : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductStatusId { get; set; }
        public string ProductStatusName { get; set; }
        public List<Product> Products { get; set; }
    }
}
