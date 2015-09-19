using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;

namespace Padaria.Web.Controllers
{
    public class CreditController : Controller
    {
        /*public int CreditID { get; set; }
        public int CustomerID { get; set; }
        public decimal Value { get; set; }
        public int UserID { get; set; }
        public virtual Users Users { get; set; }
        public virtual Customer Customer { get; set; }*/

        public CreditRepository _creditRepository { get; } = new CreditRepository();
        public UserRepository _userRepository { get; } = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Create([Bind(Include = "CustomerID,Value")] Credit credit)
        {
            credit.UserID = _userRepository.GetUserIDWithUserName(Login.User_Name);
            return Json(new { result = _creditRepository.Creates(credit) }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public PartialViewResult Recieve()
        {

            //------------------------A mature way----------------------------
            var genericList = (_creditRepository.GetAlls().GroupBy(a => new
            {
                a.Users,
                a.Customer,
                a.CustomerID
            }).Select(b => new Credit
            {
                Customer = new Customer { Name = b.Key.Customer.Name },
                Value = b.Sum(c => c.Value),
                Users = new Users { UserName = b.Key.Users.UserName },
                CustomerID = b.Key.CustomerID
            }));


            return PartialView(genericList);

            //------------------------A noob way----------------------------

            //var genericList = (_creditRepository.GetAlls().GroupBy(a => new
            //{
            //    a.Users,
            //    a.Customer,
            //    a.UserID
            //}).Select(b => new
            //{
            //    b.Key.Customer.Name,
            //    Value = b.Sum(c => c.Value),
            //    b.Key.Users.UserName,
            //    b.Key.UserID
            //})).Distinct();

            //List<Credit> creditList = new List<Credit>();

            //genericList.ToList().ForEach(c => creditList.Add(new Credit()
            //{
            //    Customer = new Customer { Name = c.Name },
            //    Users = new Users { FullName = c.UserName},
            //    Value = c.Value,
            //    UserID = _userRepository.GetUserIDWithUserName(c.UserName)

            //}));

            //return PartialView(creditList);

        }


    }
}