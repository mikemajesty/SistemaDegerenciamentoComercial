using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.ComponentModel;

namespace Padaria.Web.Models
{
    public class RecieveCreditViewModel
    {
        public decimal Value { get; set; }
        public List<Customer> Customer { get; set; }
        [DisplayName(displayName: "Customer Name")]
        public string CustomerName { get; set; }
    }
}