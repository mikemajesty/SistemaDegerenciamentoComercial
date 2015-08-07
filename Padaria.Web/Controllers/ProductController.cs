using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ProductRepository _productRepository = null;
        private StockRepository _stockRepository = null;
        private TypeOfRegistrationRepository _typeOfRegistrationRepository = null;
        private const int Insuccess = 0;
        private void InstantiateStockRepository()
        {
            _stockRepository = new StockRepository();
        }
        private void InstantiateProductRepository()
        {
            _productRepository = new ProductRepository();
        }
        private ProductViewModel ReturnProductViewModel()
        {

            return new ProductViewModel
            {
                Category = LoadCategory(0),
                TypeOfRegistration = LoadTypeOfRegistration(0)
            };
        }

        private SelectList LoadTypeOfRegistration(int typeOfRegistrationID)
        {

            InstantiateTypeOfRegistrationRepository();
            return new SelectList(items: _typeOfRegistrationRepository.DataContext.TypeOfRegistration, dataValueField: "TypeOfRegistrationID", dataTextField: "Name", selectedValue: typeOfRegistrationID);
        }

        private void InstantiateTypeOfRegistrationRepository()
        {
            _typeOfRegistrationRepository = new TypeOfRegistrationRepository();
        }
        private ProductViewModel ReturnProduct(int productID)
        {
            InstantiateProductRepository();
            InstantiateStockRepository();
            InstantiateTypeOfRegistrationRepository();
            Product prod = _productRepository.GetByIds(productID);
            return new ProductViewModel
            {
                Product = prod,
                Category = LoadCategory(prod.CategoryID),
                Stock = _stockRepository.GetByIDs(productID),
                TypeOfRegistration = LoadTypeOfRegistration(prod.TypeOfRegistrationID)

            };
        }
        private SelectList LoadCategory(int categoryID)
        {
            InstantiateProductRepository();
            return new SelectList(items: _productRepository.DataContext.Category, dataValueField: "CategoryID", dataTextField: "Name", selectedValue: categoryID);
        }
        //-----------------------------------------------------------//

        [HttpGet]
        public ActionResult List()
        {
            InstantiateProductRepository();
            return View(_productRepository.GetAlls());
        }
        [HttpGet]
        public ActionResult Create()
        {
            /*****************************************/
            try
            {
                return View(ReturnProductViewModel());
            }
            catch (DbEntityValidationException error)
            {

                foreach (var result in error.EntityValidationErrors)
                {
                    foreach (var e in result.ValidationErrors)
                    {
                        ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                    }

                }
                return View(ReturnProductViewModel());
            }

        }
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            InstantiateProductRepository();
            if (ModelState.IsValid && _productRepository.Creates(productViewModel.Product) != Insuccess)
            {
                productViewModel.Stock.ProductID = productViewModel.Product.ProductID;
                InstantiateStockRepository();
                _stockRepository.Creates(productViewModel.Stock);
                return RedirectToAction("List");
            }
            return View(ReturnProductViewModel());
        }
        [HttpGet]
        public ActionResult Details(int productID)
        {

            return View(ReturnProduct(productID));
        }
        [HttpGet]
        public ActionResult Delete(int productID)
        {

            return View(ReturnProduct(productID));
        }
        [HttpPost]
        public ActionResult Delete(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                InstantiateProductRepository();
                Product prod = _productRepository.GetByIds(productViewModel.Product.ProductID);
                if (_productRepository.Deletes(prod) != Insuccess)
                {
                    return RedirectToAction("List");
                }
                productViewModel.Category = LoadCategory(productViewModel.Product.CategoryID);
                return View(productViewModel);
            }
            return View(productViewModel);

        }
        [HttpGet]
        public ActionResult Edit(int productID)
        {
            return View(ReturnProduct(productID));
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                InstantiateProductRepository();
                InstantiateStockRepository();
                if ((_productRepository.Updates(productViewModel.Product) != Insuccess)
                      && (_stockRepository.Update(productViewModel.Stock) != Insuccess))
                {
                    return RedirectToAction("List");
                }

            }
            return View(ReturnProduct(productViewModel.Product.ProductID));
        }
    }
}