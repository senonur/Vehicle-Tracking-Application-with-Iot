using IotShipmentProject.Core.Business.Abstract;
using IotShipmentProject.Core.Entity.Concrete;
using System.Web;
using System.Web.Mvc;

namespace IotShipmentProject.Core.MvcUI.Concrete
{
    public class BaseController<TEntity, TService> : Controller
        where TEntity : CoreEntity, new()
        where TService : IService<TEntity>
    {
        private readonly TService _service;

        public BaseController(TService service) => _service = service;

        [HttpGet]
        public virtual ActionResult Index() => View(_service.GetAll());

        [HttpGet]
        public virtual ActionResult Details(int? id) => GetEntityById(id);

        [HttpGet]
        public virtual ActionResult Create() => View();

        [HttpPost]
        public virtual ActionResult Create(TEntity entity, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _service.Add(entity);
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        [HttpGet]
        public virtual ActionResult Edit(int? id) => GetEntityById(id);

        [HttpPost]
        public virtual ActionResult Edit(TEntity entity, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                _service.Update(entity);
                return Redirect($"~/{typeof(TEntity).Name}s/Edit/{entity.Id}");
            }

            return View(entity);
        }

        [HttpGet]
        public virtual ActionResult ChangeStatus(int? id) => GetEntityById(id, true);

        [HttpGet]
        public virtual ActionResult Delete(int? id) => GetEntityById(id);

        [HttpPost, ActionName("Delete")]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(_service.GetById(id));
            return Content(Utility.RedirectWithMessage($"{Utility.Translate(typeof(TEntity).Name)} silindi. Listeye yönlendiriliyorsunuz.", $"{typeof(TEntity).Name}s", duration: 1.0));
        }

        [NonAction]
        public virtual ActionResult GetEntityById(int? id, bool changeStatus = false)
        {
            if (id == null)
                return Content(Utility.RedirectWithMessage("Hatalı işlem gerçekleşti. Listeye yönlendiriliyorsunuz.", $"{typeof(TEntity).Name}s"));

            TEntity entity = _service.GetById((int)id);

            if (entity == null)
            {
                ViewBag.PanelErrorMessage = $"{Utility.Translate(typeof(TEntity).Name)} bulunamadı.";
                ViewBag.GoBackLink = $"/{typeof(TEntity).Name}s/Index";
                return View("Error");
            }

            if (changeStatus)
            {
                entity.Status = entity.Status == Status.Active ? Status.Passive : Status.Active;
                _service.Update(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }
    }
}