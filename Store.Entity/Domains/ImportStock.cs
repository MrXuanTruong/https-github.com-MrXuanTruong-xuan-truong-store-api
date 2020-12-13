using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ImportStock")]
    public class ImportStock : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ImportStockId { get; set; }

        public string ImportStockCode { get; set; }

        public long BranchId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
