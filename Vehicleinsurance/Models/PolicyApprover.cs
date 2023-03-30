using System;
using System.Collections.Generic;

namespace VehicleInsurance_81380.Models
{
    public partial class PolicyApprover
    {
        public PolicyApprover()
        {
            PolicyClaim = new HashSet<PolicyClaim>();
        }

        public int AgentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CompanyId { get; set; }

        public PolicyCompany Company { get; set; }
        public ICollection<PolicyClaim> PolicyClaim { get; set; }
    }
}
