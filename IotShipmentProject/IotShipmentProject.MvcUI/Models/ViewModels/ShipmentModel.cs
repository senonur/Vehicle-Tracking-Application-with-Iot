using IotShipmentProject.Entity.Concrete;
using System.Collections.Generic;

namespace IotShipmentProject.MvcUI.Models.ViewModels
{
    public class ShipmentModel
    {
        public Shipment Shipment { get; set; }
        public List<IotCar> IotCars { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<ShipmentState> ShipmentStates { get; set; } = new List<ShipmentState> { ShipmentState.Active, ShipmentState.Completed, ShipmentState.Preparing, ShipmentState.Waiting };
    }
}