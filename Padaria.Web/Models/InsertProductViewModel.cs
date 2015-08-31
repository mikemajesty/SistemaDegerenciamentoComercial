
using Padaria.Repository.Entities;
using System.Collections.Generic;

namespace Padaria.Web.Models
{
    public class InsertProductViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal FullIncome { get; set; }
        public decimal FullSale { get; set; }
        public Controls Controls { get; set; }
        //public List<Product> Products { get; set; }
    }
}