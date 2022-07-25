using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Entity.Concrete;
using IotShipmentProject.MvcUI.Models.ViewModels;
using System.Web.Mvc;

namespace IotShipmentProject.MvcUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IIotCarService _iotCarService;
        private readonly IDriverService _driverService;
        private readonly IShipmentService _shipmentService;

        public DashboardController(IIotCarService iotCarService, IDriverService driverService, IShipmentService shipmentService)
        {
            _iotCarService = iotCarService;
            _driverService = driverService;
            _shipmentService = shipmentService;
        }

        public ActionResult Index() => View(new DashboardModel()
        {
            IotCarCount = _iotCarService.GetCount(),
            DriverCount = _driverService.GetCount(),
            ActiveShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Active),
            CompletedShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Completed),
            WaitingShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Waiting),
            PreparingShipmentCount = _shipmentService.GetCount(a => a.ShipmentState == ShipmentState.Preparing),
            Shipments = _shipmentService.GetAll(),
            IotCars = _iotCarService.GetAll(),
            Drivers = _driverService.GetAll(),
        });
    }
}