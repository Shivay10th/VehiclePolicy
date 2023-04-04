using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicleinsurance.DTOs.VehicleDtos
{
    public class VehiclePostDto
    {
        public string VehicleType { get; set; }
        public string VehicleRegistrationNo { get; set; }
        public string VehicleChassisNo { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public DateTime? VehicleRegistraionDate { get; set; }

    }
}
