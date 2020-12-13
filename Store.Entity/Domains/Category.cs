using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Categories")]
    public class Category: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryId { get; set; }
        
        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string Description  { get; set; }
        public List<Product> Products { get; set; }
    }
}
