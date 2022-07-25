using IotShipmentProject.Core.Entity.Concrete;

namespace IotShipmentProject.Entity.Concrete
{
    public class Shipment : CoreEntity
    {
        public int IotCarId { get; set; }
        public int DriverId { get; set; }
        public string ShipmentNumber { get; set; }
        public string Product { get; set; }
        public ShipmentState ShipmentState { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }

        public IotCar IotCar { get; set; }
        public Driver Driver { get; set; }
    }

    public enum ShipmentState { Completed, Active, Preparing, Waiting }
}