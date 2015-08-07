using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Padaria.Repository.Entities
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "{0} exceeded the registration limit")]
        public int PermissionID { get; set; }
        [StringLength(maximumLength: 15, ErrorMessage = "{0} can only contains 1 characters")]
        [Required(ErrorMessage="{0} is obligatory")]
        public string Name { get; set; }
    }
}
