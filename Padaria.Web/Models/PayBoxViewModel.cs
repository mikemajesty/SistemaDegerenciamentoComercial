using Padaria.Repository.Entities;


namespace Padaria.Web.Models
{
    public class PayBoxViewModel
    {
        public PayBox Paybox { get; set; }
        public Product Product { get; set; }
        public Stock Stock { get; set; }
        
    }
}