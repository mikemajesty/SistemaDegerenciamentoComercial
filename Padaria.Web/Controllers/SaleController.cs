using Padaria.Repository.Repository;
using Padaria.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Padaria.Web.Controllers
{
    public class SaleController : Controller
    {

        //private UserRepository _userRepository { get; } = new UserRepository();
        //private TypeOfPaymentRepository _typeOfPaymentRepository { get; } = new TypeOfPaymentRepository();
        private SaleRepository _saleRepository { get; } = new SaleRepository();

        public ActionResult List()
        {
            return View(new SaleAndIncomeViewModel
            {
                    
                 Sale = _saleRepository.GetAlls()

            });
        }
        //return View(new SaleViewModel
        //   {
        //       TypeOfPayment = GetTypeOfPayment(),
        //        User = GetUser()
        //   });
        //private SelectList GetUser(int userID = 0)
        //{
        //    return new SelectList(_userRepository.GetAlls(), "UserID", "UserName", userID);
        //}
        //private SelectList GetTypeOfPayment(int typeOfPayment = 0)
        //{
        //    return new SelectList(_typeOfPaymentRepository.GetAlls(), "TypeOfPaymentID", "Type", typeOfPayment);
        //}
    }
}