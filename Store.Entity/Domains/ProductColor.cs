using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductColors")]
    public class ProductColor:Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductColorId { get; set; }
        [Required]
        [StringLength(100)] 
        public String ProductColorName { get; set; }
        [StringLength(50)]
        public decimal Price { get; set; }
        [StringLength(50)]
        public String ProductId { get; set; }
        [NotMapped]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
