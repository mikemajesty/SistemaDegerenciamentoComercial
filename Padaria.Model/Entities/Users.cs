using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padaria.Repository.Entities
{
    [Table(name: nameof(Users))]
    public class Users
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        public int UserID { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contains 20 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        [DisplayName(displayName: "User Name")]
        public string UserName { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contains 20 characters")]
        [Required(ErrorMessage = "{0} is obligatory")]
        public string PassWord { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 20, ErrorMessage = "{0} can only contains 20 characters")]
        [DisplayName(displayName: "Confirm password")]
        [Compare(otherProperty: "PassWord", ErrorMessage = "PassWords are not equals")]
        public string ConPassWord { get; set; }

        [DisplayName(displayName: "Permission")]
        public int PermissionID { get; set; }

        [DisplayName(displayName: "Last Access")]
        [DataType(dataType: DataType.Date, ErrorMessage = "{0} is invalid")]
        public DateTime LastAccess { get; set; }

        [DisplayName(displayName: "Full Name")]
        [StringLength(maximumLength: 50, ErrorMessage = "{0} can only constain 50 characters")]
        public string FullName { get; set; }

        public virtual Permission Permission { get; set; }

       
    }
}
