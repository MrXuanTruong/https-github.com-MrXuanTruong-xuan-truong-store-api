using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Permissions")]
    public class Permission : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PermissionId { get; set; }
        public string PermissionName { get; set; }
        public List<AccountPermission> AccountPermissions { get; set; }
    }
}
