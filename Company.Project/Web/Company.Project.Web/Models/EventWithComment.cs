using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public class EventWithComment
    {
        public int Id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string location { get; set; }
        public string startTime { get; set; }
        public int duration { get; set; }
        public string description { get; set; }
        public string otherDetails { get; set; }
        public List<string> commenterName { get; set; }
        public List<string> comments { get; set; }
    }
}
