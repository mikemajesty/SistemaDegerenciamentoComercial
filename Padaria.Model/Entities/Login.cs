using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Padaria.Repository.Entities
{
    public class Login
    {
        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contains 20 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contains 20 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        public string PassWord { get; set; }
    }
}
