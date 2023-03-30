using System;
using System.Collections.Generic;

namespace VehicleInsurance_81380.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            VehiclePolicy = new HashSet<VehiclePolicy>();
        }

        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleRegistrationNo { get; set; }
        public string VehicleChassisNo { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public DateTime? VehicleRegistraionDate { get; set; }
        public int? OwnerId { get; set; }

        public PolicyHolder Owner { get; set; }
        public ICollection<VehiclePolicy> VehiclePolicy { get; set; }
    }
}
