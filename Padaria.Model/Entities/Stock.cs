using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name: nameof(Stock))]
    public class Stock
    {
        [Key]
        [ForeignKey("Product")]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        [DisplayName(displayName: "Minimun Quantity")]
        public int MinimunQuantity { get; set; }
        [DisplayName(displayName: "Maximun Quantity")]
        public int MaximunQuantity { get; set; }
        [DisplayName(displayName: "Manager Stock")]
        public bool ManageStock { get; set; }
        public virtual Product Product { get; set; }
    }
}
