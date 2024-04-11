using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Company.Project.Web.Models
{
    public class EventTitles
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Title can not be null")]
        public string title { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Title can not be null")]
        public string location { get; set; }
        public string startTime { get; set; }
        [Required]
        public bool type { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public string otherDetails { get; set; }
        public string inviteByEmail { get; set; }
        [Required]
        public int userId { get; set; }

    }
}
