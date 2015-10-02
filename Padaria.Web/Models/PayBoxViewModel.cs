using Padaria.Repository.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Padaria.Web.Models
{
    public class PayBoxViewModel
    {
        public PayBox Paybox { get; set; }
        public Product Product { get; set; }
        public Stock Stock { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only have between 3 and 30 characters", MinimumLength = 3)]
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "Control Code")]
        public string ControlsCode { get; set; }
        [DisplayName(displayName: "Type Of Payment")]
        public SelectList TypeOfPayment { get; set; }
        public Sale Sale { get; set; }
        [Range(minimum: 1, maximum: 500, ErrorMessage = "{0} can only contain between 1 and 500 unity")]
        [Required(ErrorMessage = "{0} is obligatory")]
        public int Quantity { get; set; }
        public decimal Transshipment { get; set; }
        [DisplayName(displayName: "Value Paid")]
        public decimal ValuePaid { get; set; }
        [DisplayName(displayName: "Sell by Weight")]
        public bool SellByWeight { get; set; }
    }
}