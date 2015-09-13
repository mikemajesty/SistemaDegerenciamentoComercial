using Padaria.Repository.Entities;
using System.Collections.Generic;

namespace Padaria.Web.Models
{
    public class RecieveCreditViewModel
    {
        public decimal Value { get; set; }
        public List<Customer> Customer { get; set; }
    }
}