using IotShipmentProject.Business.Abstract;
using IotShipmentProject.Core.Entity.Concrete;
using IotShipmentProject.Core.MvcUI.Concrete;
using IotShipmentProject.Entity.Concrete;
using IotShipmentProject.MvcUI.Models.ViewModels;
using System.Web.Mvc;

namespace IotShipmentProject.MvcUI.Controllers
{
    public class IotCarsController : Controller
    {
        private readonly IIotCarService _iotCarService;
        private readonly IDeviceService _deviceService;
        
        public IotCarsController(IIotCarService iotCarService, IDeviceService deviceService)
        {
            _iotCarService = iotCarService;
            _deviceService = deviceService;
        }

        [HttpGet]
        public ActionResult Index() => View(_iotCarService.GetAll());

        [HttpGet]
        public ActionResult Create() => View(new IotCarsModel()
        {
            Devices = _deviceService.GetAll(d => d.Status == Status.Active)
        });

        [HttpPost]
        public ActionResult Create(IotCar iotCar, int DeviceId)
        {
            IotCar iotCarToAdd = iotCar;
            iotCarToAdd.DeviceId = DeviceId;

            if (ModelState.IsValid)
            {
                _iotCarService.Add(iotCarToAdd);
                return RedirectToAction("Index");
            }

            return View(iotCar);
        }

        [HttpGet]
        public ActionResult Edit(int? id) => GetIotCarById(id, false, true);

        [HttpPost]
        public ActionResult Edit(IotCar iotCar, int Id, int DeviceId)
        {
            IotCar iotCarToUpdate = iotCar;
            iotCarToUpdate.Id = Id;
            iotCarToUpdate.DeviceId = DeviceId;

            if (ModelState.IsValid)
            {
                _iotCarService.Update(iotCarToUpdate);
                return Redirect($"~/IotCars/Edit/{iotCarToUpdate.Id}");
            }

            return View(iotCar);
        }

        [HttpGet]
        public ActionResult ChangeStatus(int? id) => GetIotCarById(id, true);

        [HttpGet]
        public ActionResult Delete(int? id) => GetIotCarById(id);

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _iotCarService.Delete(_iotCarService.GetById(id));
            return Content(Utility.RedirectWithMessage($"IOT araç silindi. Listeye yönlendiriliyorsunuz.", "IotCars", duration: 1.0));
        }

        [NonAction]
        public ActionResult GetIotCarById(int? id, bool changeStatus = false, bool returnWithModel = false)
        {
            if (id == null)
                return Content(Utility.RedirectWithMessage("Hatalı işlem gerçekleşti. Listeye yönlendiriliyorsunuz.", "IotCars"));

            IotCar iotCar = _iotCarService.GetById((int)id);

            if (iotCar == null)
            {
                ViewBag.PanelErrorMessage = $"IOT araç bulunamadı.";
                ViewBag.GoBackLink = $"/IotCars/Index";
                return View("Error");
            }

            if (returnWithModel)
            {
                return View(new IotCarsModel()
                {
                    Devices = _deviceService.GetAll(d => d.Status == Status.Active),
                    IotCar = iotCar
                });
            }

            if (changeStatus)
            {
                iotCar.Status = iotCar.Status == Status.Active ? Status.Passive : Status.Active;
                _iotCarService.Update(iotCar);
                return RedirectToAction("Index");
            }

            return View(iotCar);
        }
    }
}