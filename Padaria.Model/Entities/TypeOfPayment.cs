
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{

    [Table(name:nameof(TypeOfPayment))]
    public class TypeOfPayment
    {
        public int TypeOfPaymentID { get; set; }
        public string Type { get; set; }
    }

}
