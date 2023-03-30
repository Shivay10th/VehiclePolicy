using System;
using System.Collections.Generic;

namespace VehicleInsurance_81380.Models
{
    public partial class PolicyHolder
    {
        public PolicyHolder()
        {
            PolicyClaim = new HashSet<PolicyClaim>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int HolderId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string CurrentAddress { get; set; }
        public string HPassword { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PanNo { get; set; }
        public int AdharNo { get; set; }
        public ICollection<PolicyDetail> PolicyDetails { get; set; }

        public ICollection<PolicyClaim> PolicyClaim { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
