using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Colors")]
    public class Color : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ColorId { get; set; } // auto

        [StringLength(100)]
        public string ColorName { get; set; } // trăng | đen

        public List<ProductColor> ProductColors { get; set; }
    }
}
