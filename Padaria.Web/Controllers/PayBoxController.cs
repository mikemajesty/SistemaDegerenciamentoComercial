using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class PayBoxController : Controller
    {
       
        public PayBoxRepository _payBoxRepository { get; } = new PayBoxRepository();
        public ProductRepository _productRepository { get; } = new ProductRepository();

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
        public ActionResult InsertProduct(InsertProductViewModel insertProductViewModel)
        {
            Product product = _productRepository.DataContext.Product.FirstOrDefault(c => c.Code == insertProductViewModel.Product.Code);
            insertProductViewModel.Product = product;
            insertProductViewModel.FullSale = product.SalePrice * insertProductViewModel.Quantity;
            List<InsertProductViewModel> list = new List<InsertProductViewModel>();

            list.Add(insertProductViewModel);
            return PartialView(list);
        }
        public SelectList GetTypeOfPayment(int typeOfRegistrationID = 0)
        {
            return new SelectList(items: _payBoxRepository._dataContext.TypeOfPayment.ToList()
                                 , dataTextField: "Type"
                                 , dataValueField: "TypeOfPaymentID"
                                 , selectedValue:typeOfRegistrationID);
        }
    }
}