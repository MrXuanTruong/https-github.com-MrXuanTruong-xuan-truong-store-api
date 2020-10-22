using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Products")]
    public class Product: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { set; get; }
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public int CategoryId { get; set; }
        [NotMapped]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [StringLength(50)]
        public decimal Price { set; get; }
        //[StringLength(50)]
        //public decimal OriginalPrice { set; get; }
        [StringLength(50)]
        public int Stock { set; get; }
        [StringLength(100)]
        public int ViewCount { set; get; }
        [StringLength(200)]
        public string Description { set; get; }
        [StringLength(50)]
        public DateTime DateCreated { set; get; }
        
    }
}
