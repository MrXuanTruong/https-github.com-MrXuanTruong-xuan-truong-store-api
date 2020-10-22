using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductBranches")]
    public class ProductBranch:Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductBranchId { get; set; }
        public String ProductId { get; set; }
        [NotMapped]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
