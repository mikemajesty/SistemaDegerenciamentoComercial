using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        public int ProductID { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only contain 30 characters.")]
        [Required(ErrorMessage = "{0} is obligatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is obligatory")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contain 30 characters.")]
        public string Code { get; set; }
        [DisplayName(displayName:"Category")]     
        public int CategoryID { get; set; }
        [DisplayName(displayName: "Type Of Registration")]
        public int TypeOfRegistrationID { get; set; }
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "Purchase Price")]
        [Range(minimum: 0.00, maximum: double.MaxValue, ErrorMessage = "{0} contains invalid values")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "Sale Price")]
        [Range(minimum: 0.05, maximum: double.MaxValue, ErrorMessage = "{0} contains invalid values")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public decimal SalePrice { get; set; }
        
        [DataType(dataType: DataType.MultilineText)]
        [StringLength(maximumLength: 100, ErrorMessage = "{0} can only contain 30 characters.")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "{0} is obligatory")]
        public virtual Category Category { get; set; }
       // [Required(ErrorMessage = "{0} is obligatory")]
        public virtual Stock Stock { set; get; }
        //[Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "Type Of Registration")]
        public virtual TypeOfRegistration TypeOfRegistration { get; set; }

    }
}
