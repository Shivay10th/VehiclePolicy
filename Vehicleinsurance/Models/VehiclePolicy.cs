using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleInsurance_81380.Models
{
    public partial class VehiclePolicy
    {
        public VehiclePolicy()
        {
            PolicyClaim = new HashSet<PolicyClaim>();
        }

        public int PolicyId { get; set; }
        public int? CompanyId { get; set; }
        public string PolicyName { get; set; }
        public decimal? TotalPayableAmt { get; set; }
        public decimal? IDV { get; set; }
        [Column(TypeName = "Date")]
        public DateTime PolicyRegistrationDate { get; set; }
        [Column(TypeName="Date")]
        public DateTime PolicyEndDate { get; set; }


        /*Navigation properties*/
        public PolicyCompany Company { get; set; }

        public ICollection<PolicyClaim> PolicyClaim { get; set; }


    }
}
