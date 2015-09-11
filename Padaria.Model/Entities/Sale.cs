using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Entities
{
    [Table(name:nameof(Sale))]
    public class Sale
    {
        public int SaleID { get; set; }
        [DisplayName(displayName: "Full Sale")]
        public decimal FullSale { get; set; }
        [DisplayName(displayName: "Full Income")]
        public decimal FullIncome { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        [DisplayName(displayName: "Type Of Payment")]
        public int TypeOfPaymentID { get; set; }
        public virtual Users User{ get; set; }
        [DisplayName(displayName: "Type Of Payment")]
        public virtual TypeOfPayment TypeOfPayment { get; set; }

    }
}
