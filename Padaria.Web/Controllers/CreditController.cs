using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    public class CreditController : Controller
    {

        public CreditRepository _creditRepository { get; } = new CreditRepository();
        public UserRepository _userRepository { get; } = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Create([Bind(Include = "CustomerID,Value")] Credit credit)
        {
            credit.UserID = _userRepository.GetUserIDWithName(Login.User_Name);
            return Json(new { result = _creditRepository.Creates(credit) }, JsonRequestBehavior.AllowGet);
        }
           

    }
}