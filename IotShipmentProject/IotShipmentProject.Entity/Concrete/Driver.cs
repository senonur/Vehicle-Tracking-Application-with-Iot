using IotShipmentProject.Core.Entity.Concrete;
using System.Collections.Generic;

namespace IotShipmentProject.Entity.Concrete
{
    public class Driver : CoreEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string IdentityNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string DrivingLicenceType { get; set; }

        public List<Shipment> Shipments { get; set; }
    }
}