using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductBranches")]
    public class ProductBranch : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductBranchId { get; set; }
        public int? LocalStock { set; get; } // Hàng tồn kho
        
        public long? ProductId { set; get; } //1

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public long BranchId { get; set; } // 1: thủ đúc

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public long? ColorId { get; set; }

        [ForeignKey("ColorId")]
        public Color Color { get; set; }

    }
}
