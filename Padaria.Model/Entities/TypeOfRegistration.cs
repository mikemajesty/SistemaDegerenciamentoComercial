using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name: "TypeOfRegistration")]
    public class TypeOfRegistration
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        public int TypeOfRegistrationID { get; set; }
        [Required(ErrorMessage="{0} is obligatory")]
        [StringLength(maximumLength: 10, ErrorMessage = "{0} can only contain 10 characters.")]
        public string Name { get; set; }
    }
}
