using System;
using System.Web.Mvc;
using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.Entity.Concrete;
using IotShipmentProject.Core.MvcUI.Concrete;
using IotShipmentProject.Entity.Concrete;
using IotShipmentProject.MvcUI.Models.ViewModels;

namespace IotShipmentProject.Areas.Admin.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly IShipmentService _shipmentService;
        private readonly IIotCarService _iotCarService;
        private readonly IDriverService _driverService;

        public ShipmentsController(IShipmentService shipmentService, IIotCarService iotCarService, IDriverService driverService)
        {
            _shipmentService = shipmentService;
            _iotCarService = iotCarService;
            _driverService = driverService;
        }

        [HttpGet]
        public ActionResult Index() => View(new ShipmentIndexModel()
        {
            IotCars = _iotCarService.GetAll(),
            Drivers = _driverService.GetAll(),
            Shipments = _shipmentService.GetAll()
        });

        [HttpGet]
        public ActionResult Create() => View(new ShipmentModel()
        {
            IotCars = _iotCarService.GetAll(i => i.Status == Status.Active),
            Drivers = _driverService.GetAll(d => d.Status == Status.Active)
        });

        [HttpPost]
        public ActionResult Create(Shipment shipment, int IotCarId, int DriverId)
        {
            Shipment shipmentToAdd = shipment;
            shipmentToAdd.IotCarId = IotCarId;
            shipmentToAdd.DriverId = DriverId;
            shipmentToAdd.ShipmentNumber = Guid.NewGuid().ToString();

            if (ModelState.IsValid)
            {
                _shipmentService.Add(shipmentToAdd);
                return RedirectToAction("Index");
            }

            return View(shipment);
        }

        [HttpGet]
        public ActionResult Edit(int? id) => GetShipmentById(id, true);

        [HttpPost]
        public ActionResult Edit(Shipment shipment, int IotCarId, int DriverId)
        {
            Shipment shipmentToUpdate = shipment;
            shipmentToUpdate.IotCarId = IotCarId;
            shipmentToUpdate.DriverId = DriverId;

            if (ModelState.IsValid)
            {
                _shipmentService.Update(shipmentToUpdate);
                return Redirect($"~/Shipments/Edit/{shipmentToUpdate.Id}");
            }

            return View(shipment);
        }

        [HttpGet]
        public ActionResult Delete(int? id) => GetShipmentById(id, true);

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _shipmentService.Delete(_shipmentService.GetById(id));
            return Content(Utility.RedirectWithMessage("Sevkiyat silindi. Listeye yönlendiriliyorsunuz.", "Shipments", duration: 1.0));
        }

        [NonAction]
        public ActionResult GetShipmentById(int? id, bool returnWithModel = false, string errorMessage = "Sevkiyat bulunamadı.", string goBackLink = "/Shipments/Index")
        {
            if (id == null)
                return Content(Utility.RedirectWithMessage("Hatalı işlem gerçekleşti. Listeye yönlendiriliyorsunuz.", "Shipments"));

            Shipment shipment = _shipmentService.GetById((int)id);

            if (shipment == null)
            {
                ViewBag.PanelErrorMessage = errorMessage;
                ViewBag.GoBackLink = goBackLink;
                return View("Error");
            }

            return returnWithModel
                ? View(new ShipmentModel()
                {
                    IotCars = _iotCarService.GetAll(),
                    Drivers = _driverService.GetAll(),
                    Shipment = shipment
                })
                : View(shipment);
        }
    }
}