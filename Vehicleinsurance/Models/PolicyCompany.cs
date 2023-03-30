using System;
using System.Collections.Generic;

namespace VehicleInsurance_81380.Models
{
    public partial class PolicyCompany
    {
        public PolicyCompany()
        {
            PolicyApprover = new HashSet<PolicyApprover>();
            VehiclePolicy = new HashSet<VehiclePolicy>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string CPassword { get; set; }

        public ICollection<PolicyApprover> PolicyApprover { get; set; }
        public ICollection<VehiclePolicy> VehiclePolicy { get; set; }
    }
}
