using IotShipmentProject.Core.MvcUI.Concrete;
using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Entity.Concrete;

namespace IotShipmentProject.MvcUI.Controllers
{
    public class DriversController : BaseController<Driver, IDriverService>
    {
        public DriversController(IDriverService driverService) : base(driverService)
        {
        }
    }
}