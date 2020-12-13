using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("ExportStock")]
    public class ExportStock : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ExportStockId { get; set; }
        public long FromBranchId { get; set; }

        public long ToBranchId { get; set; }

        public string ExportStockCode { get; set; }

        public long OrderId { get; set; }

        [StringLength(200)]
        public string Note { get; set; }
    }
}
