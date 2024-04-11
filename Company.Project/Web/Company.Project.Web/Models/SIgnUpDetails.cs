using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Company.Project.Web.Models
{
    public class SIgnUpDetails
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"[A-Z]", ErrorMessage = "Password Should Contain an Upper case Latter")]
        [MinLength(5, ErrorMessage = "Password length should be more than 5 ")]
        public string Password { get; set; }
    }
}
