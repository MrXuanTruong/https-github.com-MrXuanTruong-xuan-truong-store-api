using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Categories")]
    public class Category:Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { set; get; }
        [Required]
        [StringLength(50)]
        public String CategoryName { set; get; }

        [StringLength(200)]
        public String Description  { set; get; }
        [StringLength(100)]
        public String Image { set; get; }
    }
}
