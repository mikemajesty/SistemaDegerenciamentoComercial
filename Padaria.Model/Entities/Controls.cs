using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name:"Control")]
    public class Controls
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        [DisplayName(displayName: "Control ID")]
        public int ControlID { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "{0} can only have a 30 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "Control Code")]
        public string Code { get; set; }
    }
}
