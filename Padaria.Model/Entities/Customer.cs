using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name:"Customer")]
    public class Customer
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        [DisplayName(displayName: "Customer ID")]
        public int CustomerID { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only have 30 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        public string Name { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only have 15 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        [DataType(dataType:DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only have 15 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        public string CPF { get; set; }
    }
}
