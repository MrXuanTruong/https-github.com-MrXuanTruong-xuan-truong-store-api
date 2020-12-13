using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Models.Operator
{
    public class OperatorRequestModel
    {
        public long Id { get; set; }
       
        public string Fullname { get; set; }
        
        public string Username { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public long? AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public long? AccountStatusId { get; set; }
        public string AccountStatusName { get; set; }
        public long? BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
