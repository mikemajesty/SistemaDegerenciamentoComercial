using Padaria.Repository.Entities;
using System.Web.Mvc;
namespace Padaria.Web.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public Stock Stock { get; set; }
        public SelectList Category { get; set; }
        public SelectList TypeOfRegistration { get; set; }
    }
}