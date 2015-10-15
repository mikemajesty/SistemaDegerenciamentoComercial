using Padaria.Repository.Entities;
using Padaria.Repository.Repository;
using System.Linq;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    [Authorize]
    public class CreditController : Controller
    {        

        public CreditRepository _creditRepository { get; } = new CreditRepository();
        public UserRepository _userRepository { get; } = new UserRepository();
        public PayBoxRepository _payBoxRepository { get; } = new PayBoxRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Create([Bind(Include = "CustomerID,Value")] Credit credit)
        {
            credit.UserID = _userRepository.GetUserIDWithUserName((Session[name: "UserName"]).ToString());
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
                a.CustomerID,
                a.UserID
            }).Select(b => new Credit
            {
                Customer = new Customer { Name = b.Key.Customer.Name },
                Value = b.Sum(c => c.Value),
                Users = new Users { UserName = b.Key.Users.UserName },
                CustomerID = b.Key.CustomerID,
                UserID = b.Key.UserID
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
        [HttpGet]
        public JsonResult FinishRecieve(int custumerID = 0,int userID = 0)
        {
            int returning = 0;
            var creditList = _creditRepository.DataContext().Where(c => c.CustomerID == custumerID);
            decimal valeu = creditList.Sum(c => c.Value);
            creditList.ToList<Credit>().ForEach(c => returning = _creditRepository.Deletes(c));
         
            if (returning > 0)
            {
                _payBoxRepository.Update(new PayBox { Value = valeu, UserID = userID  });
            }
            return Json(new {result = returning },JsonRequestBehavior.AllowGet);
        }


    }
}