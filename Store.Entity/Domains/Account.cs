using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Store.Entity.Domains
{
    [Table("Accounts")]
    public class Account : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public long AccountId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
  
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
        public long? AccountStatusId { get; set; }

        [ForeignKey("AccountStatusId")]
        public AccountStatus AccountStatus { get; set; }
        public long? AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }

        public long? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public long? VoucherId { get; set; }

        [ForeignKey("VoucherId")]
        public Voucher Voucher { get; set; }
        public List<AccountPermission> AccountPermissions { get; set; }
    }
}
