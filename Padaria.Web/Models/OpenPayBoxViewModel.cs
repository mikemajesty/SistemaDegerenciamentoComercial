
using Padaria.Repository.Entities;

namespace Padaria.Web.Models
{
    public class OpenPayBoxViewModel
    {
        public decimal Value { get; set; }
        public int  UserID { get; set; }
        public virtual Users Users { get; set; }
    }
}