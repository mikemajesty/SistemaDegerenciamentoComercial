using Padaria.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Padaria.Web.Models
{
    public class SaleViewModel
    {
        [DisplayName(displayName: "User Name")]
        public SelectList User { get; set; }
        [DisplayName(displayName: "Type Of Payment")]
        public SelectList TypeOfPayment { get; set; }
        public Sale Sale { get; set; }
    }
}