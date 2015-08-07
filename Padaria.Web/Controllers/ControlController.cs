using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    public class ControlController : Controller
    {
        private ControlRepository _controlRepository = null;
        private const int Success = 1, Insuccess = 0;
        [HttpGet]
        public ActionResult List()
        {
            InstantiateControlRepository();
            return View(_controlRepository.GetAlls());
        }
        [HttpGet]
        public ActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Controls control)
        {
            if (ModelState.IsValid && control != null)
            {
                InstantiateControlRepository();
                switch (_controlRepository.Creates(control))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                }
            }
            return View(control);
        }
        [HttpGet]
        public ActionResult Delete(int ControlID)
        {
            InstantiateControlRepository();
            if (ControlID != 0)
            {
                Controls control = _controlRepository?.GetByIDs(ControlID: ControlID);
                return View(control);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Delete(Controls control)
        {
            InstantiateControlRepository();
            switch (_controlRepository?.Deletes(control: control))
            {
                case Success:
                    return RedirectToAction(nameof(this.List));
            }
            return View(control);
        }
        [HttpGet]
        public ActionResult Edit(int ControlID)
        {
            InstantiateControlRepository();
            if (ControlID != 0)
            {
                Controls control = _controlRepository?.GetByIDs(ControlID: ControlID);
                return View(control);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Controls control)
        {
            InstantiateControlRepository();
            if (ModelState.IsValid)
            {
                switch (_controlRepository.Updates(control: control))
                {
                    case Success:
                        return RedirectToAction(nameof(this.List));
                }
            }
            return View(control);
        }
        [HttpGet]
        public ActionResult Details(int ControlID)
        {
            InstantiateControlRepository();
            Controls control = _controlRepository?.GetByIDs(ControlID: ControlID);
            return View(control);
        }
        private void InstantiateControlRepository() => _controlRepository = new ControlRepository();



    }
}