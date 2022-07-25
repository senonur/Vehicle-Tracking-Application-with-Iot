using IotShipmentProject.Entity.Concrete;
using System.Collections.Generic;

namespace IotShipmentProject.MvcUI.Models.ViewModels
{
    public class IotCarsModel
    {
        public IotCar IotCar { get; set; }
        public List<Device> Devices { get; set; }
    }
}