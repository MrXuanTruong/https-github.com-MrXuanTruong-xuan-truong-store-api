using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Branches")]
    public class Branch : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BranchId { get; set; }

        [StringLength(50)]
        public string BranchName { get; set; }

        public long? ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }

        public long? DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public long? BranchTypeId { get; set; }

        [ForeignKey("BranchTypeId")]
        public BranchType BranchType { get; set; }

    }
}
