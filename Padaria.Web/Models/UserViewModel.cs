using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padaria.Web.Models
{
    public class UserViewModel
    {
        public Users Users { get; set; }
        public SelectList Permission { get; set; }
    }
}