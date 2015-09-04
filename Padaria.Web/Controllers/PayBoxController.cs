using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Padaria.Web.Controllers
{
    [Authorize]
    public class PayBoxController : Controller
    {

        public PayBoxRepository _payBoxRepository { get; } = new PayBoxRepository();
        public ProductRepository _productRepository { get; } = new ProductRepository();
        private SaleWithActiveControlsRepository _saleWithActiveControlsRrepository { get; } = new SaleWithActiveControlsRepository();
        private ControlRepository _controlRepository { get; } = new ControlRepository();
        private static List<InsertProductViewModel> list = new List<InsertProductViewModel>();

        public PartialViewResult GetValue()
        {
            return PartialView(_payBoxRepository.GetValue());
        }
        [HttpGet]
        public ActionResult PayBox() => View(new PayBoxViewModel
        {
            TypeOfPayment = GetTypeOfPayment()
        });
      
        [HttpGet]
        public JsonResult GetFullValue(int listQuantity)
        {
            IEnumerable<decimal> full = list.Select(c => c.FullSale) ;            
            return Json(new { Result = full.Sum() },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult InsertProduct(InsertProductViewModel insertProductViewModel)
        {
            Product product = _productRepository.DataContext.Product.FirstOrDefault(c => c.Code == insertProductViewModel.Product.Code);
            if (product != null)
            {
                insertProductViewModel.Product = product;
                insertProductViewModel.FullSale = product.SalePrice * insertProductViewModel.Quantity;
                insertProductViewModel.FullIncome = product.SalePrice * insertProductViewModel.Quantity - (product.PurchasePrice * insertProductViewModel.Quantity);
                list.Add(insertProductViewModel);
                return PartialView(list);
            }
            return PartialView("Alert");
        }
        [HttpGet]
        public ActionResult GetControlItens(InsertProductViewModel insertProductViewModel)
        {

            Controls control = _controlRepository.DataContext.FirstOrDefault(c => c.Code == insertProductViewModel.ControlsCode);
            if (control != null)
            {
                foreach (var item in _saleWithActiveControlsRrepository.DataContext.Where(c => c.Controls.Code == control.Code))
                {
                    InsertProductViewModel productViewModel = new InsertProductViewModel();
                    {
                        productViewModel.ControlsCode = control.Code;
                        productViewModel.Product = _productRepository.GetByIds(item.ProductID);
                        productViewModel.FullSale = item.FullPrice;
                        productViewModel.Quantity = item.Quantity;
                        productViewModel.FullIncome = item.FullPrice - (productViewModel.Product.PurchasePrice * item.Quantity);



                    }
                    list.Add(productViewModel);

                }
                return PartialView(viewName: nameof(this.InsertProduct), model: list);
            }
            return PartialView("Alert");

        }
        public SelectList GetTypeOfPayment(int typeOfRegistrationID = 0)
        {
            return new SelectList(items: _payBoxRepository._dataContext.TypeOfPayment.ToList()
                                 , dataTextField: "Type"
                                 , dataValueField: "TypeOfPaymentID"
                                 , selectedValue: typeOfRegistrationID);
        }
        protected override void Dispose(bool disposing)
        {
            //if (disposing == fal)
            //{

            //}
            //if (disposing)
            //{
            //    _payBoxRepository._dataContext.Dispose();
            //    _productRepository.DataContext.Dispose();
            //    //list.Clear();
            //}
            //base.Dispose(disposing);
        }
    }
}