
using Padaria.Repository.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Padaria.Web.Models
{
    public class InsertProductViewModel
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal FullIncome { get; set; }
        public decimal FullSale { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only have between 3 and 30 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "Control Code")]
        public string ControlsCode { get; set; }
       
    }
}