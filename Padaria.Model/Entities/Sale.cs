using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Entities
{
    public class Sale
    {
        public int SaleID { get; set; }
        public decimal FullSale { get; set; }
        public decimal FullIncome { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
        public int TypeOfPaymentID { get; set; }
        public virtual Users User{ get; set; }
        public virtual TypeOfPayment TypeOfPayment { get; set; }

    }
}
