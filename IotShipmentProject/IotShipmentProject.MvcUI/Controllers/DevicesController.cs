using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.MvcUI.Concrete;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.MvcUI.Controllers
{
    public class DevicesController : BaseController<Device, IDeviceService>
    {
        public DevicesController(IDeviceService deviceService) : base(deviceService)
        {
        }
    }
}