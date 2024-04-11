using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int eventId { get; set; }
        public string comment { get; set; }
    }
}
