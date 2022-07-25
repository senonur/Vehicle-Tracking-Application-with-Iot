using IotShipmentProject.Entity.Concrete;
using System.Collections.Generic;

namespace IotShipmentProject.MvcUI.Models.ViewModels
{
    public class ShipmentIndexModel
    {
        public List<IotCar> IotCars { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Shipment> Shipments { get; set; }
    }
}