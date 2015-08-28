using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name:nameof(Category))]
    public class Category
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        public int CategoryID { get; set; }
        [DisplayName(displayName:"Category name")]
        [Required(ErrorMessage = "{0} is obligatory")]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contains 20 characters")]
        public string Name { get; set; }
    }
}
