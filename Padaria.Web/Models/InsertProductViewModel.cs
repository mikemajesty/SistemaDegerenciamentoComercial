
using Padaria.Repository.Entities;

namespace Padaria.Web.Models
{
    public class InsertProductViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal FullIncome { get; set; }
        public decimal FullSale { get; set; }
    }
}