

using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name:nameof(Credit))]
    public class Credit
    {
        public int CreditID { get; set; }
        public int CustomerID { get; set; }
        public decimal Value { get; set; }
        public int UserID { get; set; }
        public virtual Users Users { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
