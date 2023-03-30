using System;
using System.Collections.Generic;

namespace VehicleInsurance_81380.Models
{
    public partial class PolicyClaim
    {
        public int PolicyClaimId { get; set; }

        public decimal? ClaimAmount { get; set; }
        public string ClaimStatus { get; set; }
        public DateTime? DateOfLoss { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        /* Navigation Property */
        public int? PolicyHolderId { get; set; }
        public int? PolicyId { get; set; }
        public PolicyApprover ApprovedByNavigation { get; set; }
        public VehiclePolicy Policy { get; set; }
        public PolicyHolder PolicyHolder { get; set; }
    }
}
