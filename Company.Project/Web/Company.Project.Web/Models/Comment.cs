using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Company.Project.Web.Models
{
    public class Comment
    {
        public int itemId { get; set; }
        [Required]
        public string comment { get; set; }
    }
}
