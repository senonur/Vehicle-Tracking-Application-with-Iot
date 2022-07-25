using IotShipmentProject.Core.Entity.Concrete;
using System.Collections.Generic;

namespace IotShipmentProject.Entity.Concrete
{
    public class IotCar : CoreEntity
    {
        public int DeviceId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
        public string VehicleType { get; set; }

        public List<Shipment> Shipments { get; set; }
        public Device Device { get; set; }
    }
}