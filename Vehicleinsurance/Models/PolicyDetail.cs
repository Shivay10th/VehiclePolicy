using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleInsurance_81380.Models
{
    [Table("PolicyDetail")]
    public class PolicyDetail
    {
        public int PolicyDetailId { get; set; }

        public string Frequency { get; set; }

        public double? PaidAmt { get; set; }

        /*Navigation Property*/
        public int VehicalId { get; set; }
        public Vehicle Vehical { get; set; }

        public int PolicyId { get; set; }
        public VehiclePolicy VehicalPolicy { get; set; }
        public int PolicyHolderId { get; set; }
        public PolicyHolder PolicyHolder { get; set; }

        public ICollection<VehiclePolicy> VehicalPolicies { get; set; }
    }
}
