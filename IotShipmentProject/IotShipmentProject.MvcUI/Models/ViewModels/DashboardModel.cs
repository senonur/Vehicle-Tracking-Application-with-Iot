using IotShipmentProject.Entity.Concrete;
using System.Collections.Generic;

namespace IotShipmentProject.MvcUI.Models.ViewModels
{
    public class DashboardModel
    {
        public int ActiveShipmentCount { get; set; }
        public int CompletedShipmentCount { get; set; }
        public int WaitingShipmentCount { get; set; }
        public int PreparingShipmentCount { get; set; }
        public int IotCarCount { get; set; }
        public int DriverCount { get; set; }
        public List<Shipment> Shipments { get; set; }
        public List<IotCar> IotCars { get; set; }
        public List<Driver> Drivers { get; set; }
    }
}