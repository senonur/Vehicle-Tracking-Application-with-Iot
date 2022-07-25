using IotShipmentProject.Core.Entity.Concrete;

namespace IotShipmentProject.Entity.Concrete
{
    public class Device : CoreEntity
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }
}