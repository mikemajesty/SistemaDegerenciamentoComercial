using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
       
        private ProductRepository _productRepository { get; } = new ProductRepository();
        private TypeOfRegistrationRepository _typeOfRegistrationRepository { get; } = new TypeOfRegistrationRepository();
        private StockRepository _stockRepository { get; } = new StockRepository();
       
        private const int Insuccess = 0;       
      
        private ProductViewModel ReturnProductViewModel()
        {
            return new ProductViewModel
            {
                Category = LoadCategory(0),
                TypeOfRegistration = LoadTypeOfRegistration(0)
            };
        }

        private SelectList LoadTypeOfRegistration(int typeOfRegistrationID)
        => new SelectList(items: _typeOfRegistrationRepository.DataContext.TypeOfRegistration, 
                         dataValueField: "TypeOfRegistrationID", 
                         dataTextField: "Name", 
                         selectedValue: typeOfRegistrationID);


        private ProductViewModel ReturnProduct(int productID)
        {
            Product prod = _productRepository.GetByIds(productID);
            return new ProductViewModel
            {
                Product = prod,
                Category = LoadCategory(prod.CategoryID),
                Stock = _stockRepository.GetByIDs(productID),
                TypeOfRegistration = LoadTypeOfRegistration(prod.TypeOfRegistrationID)

            };
        }
        private SelectList LoadCategory(int categoryID) =>           
             new SelectList(items: _productRepository.DataContext.Category,
                            dataValueField: "CategoryID", 
                            dataTextField: "Name", 
                            selectedValue: categoryID);
      
        //---------------------------Interface Gráfica-----------------------------//

        [HttpGet]
        public ActionResult List() => View(_productRepository.GetAlls());

        [HttpGet]
        public ActionResult Create() => View(ReturnProductViewModel());
       
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
           
            if (ModelState.IsValid && _productRepository.Creates(productViewModel.Product) != Insuccess)
            {
                productViewModel.Stock.ProductID = productViewModel.Product.ProductID;               
                _stockRepository.Creates(productViewModel.Stock);
                return RedirectToAction(nameof(this.List));
            }
            return View(ReturnProductViewModel());
        }
        [HttpGet]
        public ActionResult Details(int productID) => View(ReturnProduct(productID));

        [HttpGet]
        public ActionResult Delete(int productID) => View(ReturnProduct(productID));

        [HttpPost]
        public ActionResult Delete(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                Product prod = _productRepository.GetByIds(productViewModel.Product.ProductID);
                if (_productRepository.Deletes(prod) != Insuccess)
                {
                    return RedirectToAction(nameof(this.List));
                }
                return HttpNotFound();
            }
            productViewModel.Category = LoadCategory(productViewModel.Product.CategoryID);
            return View(productViewModel);

        }
        [HttpGet]
        public ActionResult Edit(int productID) => View(ReturnProduct(productID));

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
               
                if ((_productRepository.Updates(productViewModel.Product) != Insuccess)
                      && (_stockRepository.Update(productViewModel.Stock) != Insuccess))
                {
                    return RedirectToAction(nameof(this.List));
                }

            }
            return View(ReturnProduct(productViewModel.Product.ProductID));
        }
    }
}