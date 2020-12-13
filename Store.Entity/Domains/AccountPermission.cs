using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("AccountPermissions")]
    public class AccountPermission : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AccountPermissionId { get; set; }
        
        public long AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public long PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }


    }
}
