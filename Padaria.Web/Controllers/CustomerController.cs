using Padaria.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padaria.Web.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerRepository _customerRepository = null;
        [HttpGet]
        public ActionResult List() => View(InstantiateCustomerRepository().GetAlls());
        [HttpPost]
        public ActionResult Create() => View();
        private CustomerRepository InstantiateCustomerRepository() => _customerRepository = new CustomerRepository();


    }
}