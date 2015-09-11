using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        
        CategoryRepository _categoryRepository = null;
        private const int Sucesso = 1;

        private void InstantiateCategoryRepository()
        {
            _categoryRepository = new CategoryRepository();
        }
        [HttpGet]
        public ActionResult List()
        {
            InstantiateCategoryRepository();
            return View(_categoryRepository.GetAlls());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Category category)
        {

            if (!ModelState.IsValid)
            {
                return View(category);
            }
            InstantiateCategoryRepository();
            if (_categoryRepository.Creates(category) == Sucesso)
            {
                return RedirectToAction("List");
            }
            return View(category);

        }
        [HttpGet]
        public ActionResult Details(int categoryID)
        {
            InstantiateCategoryRepository();
            Category category = _categoryRepository.GetByIDs(categoryID);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpGet]
        public ActionResult Edit(int categoryID)
        {
            InstantiateCategoryRepository();
            Category category = _categoryRepository.GetByIDs(categoryID);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            InstantiateCategoryRepository();
            if (_categoryRepository.Update(category) == Sucesso && ModelState.IsValid)
            {
                return RedirectToAction("List");
            }
            return View(category);
        }
        [HttpGet]
        public ActionResult Delete(int categoryID)
        {
            InstantiateCategoryRepository();
            Category category = _categoryRepository.GetByIDs(categoryID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                InstantiateCategoryRepository();
                if (_categoryRepository.Deletes(category) == Sucesso)
                    return RedirectToAction("List");

            }

            return View(category);

        }
    }
}