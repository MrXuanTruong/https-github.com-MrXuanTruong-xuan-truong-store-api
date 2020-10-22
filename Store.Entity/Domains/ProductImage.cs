using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ProductImages")]
    public class ProductImage : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductImageId { get; set; }
        [Required]
        [StringLength(200)]
        public String ProductImageUrl { get; set; }
        [StringLength(50)]
        public String ProductId { get; set; }
        [NotMapped]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
