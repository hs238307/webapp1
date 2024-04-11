using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class CombinedModel
    {
        public IEnumerable<EventWithComment> eventWithComment { get; set; }
        public Comment comment { get; set; }
    }
}
