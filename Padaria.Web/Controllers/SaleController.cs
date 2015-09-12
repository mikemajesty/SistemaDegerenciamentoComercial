using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;


namespace Padaria.Web.Controllers
{
    public class SaleController : Controller
    {


        private SaleRepository _saleRepository { get; } = new SaleRepository();
        private TypeOfPaymentRepository _typeOfPaymentRepository { get; } = new TypeOfPaymentRepository();
        public ActionResult List()
        {
            return View(new SaleAndIncomeViewModel
            {
                TypeOfPayment = GetTypeOfPayment()
            });
        }

        private SelectList GetTypeOfPayment(int typeOfPaymentID = 0)
            =>
            new SelectList(items: _typeOfPaymentRepository.GetAlls(), dataValueField: "TypeOfPaymentID", dataTextField: "Type", selectedValue: typeOfPaymentID);


        [HttpGet]
        public PartialViewResult GetRangeSale(SaleAndIncomeViewModel saleAndIncomeViewModel)
        {
            var date1 = saleAndIncomeViewModel.StartDate;
            var date2 = saleAndIncomeViewModel.FinishDate;

            date2 = date2 == DateTime.MinValue ? date1.Add(new TimeSpan(0, 23, 59, 59, 0)) : date2.Add(new TimeSpan(0, 23, 59, 59, 0));

            return PartialView(new SaleAndIncomeViewModel
            {
                FinishDate = saleAndIncomeViewModel.FinishDate,
                StartDate = saleAndIncomeViewModel.StartDate,
                Sale = _saleRepository.GetAlls().Where(c => c.Date >= date1 &&
                                                       c.Date <= date2 &&
                                                       saleAndIncomeViewModel.TypeOfPaymentID == 0 ? c.TypeOfPaymentID > 0 :
                                                       c.TypeOfPaymentID == saleAndIncomeViewModel.TypeOfPaymentID && c.Date >= date1 &&
                                                       c.Date <= date2).ToList<Sale>()
            });
        }

    }
}