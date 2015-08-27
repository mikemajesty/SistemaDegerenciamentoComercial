using Padaria.Repository.Entities;
using System.ComponentModel;
using System.Web.Mvc;

namespace Padaria.Web.Models
{
    public class PayBoxViewModel
    {
        public PayBox Paybox { get; set; }
        public Product Product { get; set; }
        public Stock Stock { get; set; }
        public Controls Controls { get; set; }
        [DisplayName(displayName: "Type Of Payment")]
        public SelectList TypeOfPayment { get; set; }
        public Sale Sale { get; set; }
    }
}