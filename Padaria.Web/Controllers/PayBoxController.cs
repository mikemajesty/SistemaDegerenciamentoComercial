using Padaria.Repository.Repository;
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
        private PayBoxRepository _payBoxRepository = null;
        public PartialViewResult GetValue()
        {
            InstantiatePayBoxRepository();
            return PartialView(_payBoxRepository.GetValue());
        }

        private void InstantiatePayBoxRepository()
        {
            _payBoxRepository = new PayBoxRepository();
        }
        [HttpGet]
        public ActionResult PayBox()
        {
            return View();
        }
    }
}