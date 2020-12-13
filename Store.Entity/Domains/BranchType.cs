using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entity.Domains
{
    [Table("BranchTypes")]
    public class BranchType: Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? BranchTypeId { get; set; }
        [StringLength(50)]
        public string BranchTypeName { get; set; }

    }
}