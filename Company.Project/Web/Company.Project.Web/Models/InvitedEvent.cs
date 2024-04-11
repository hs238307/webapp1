using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class InvitedEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int userId { get; set; }

    }
}
