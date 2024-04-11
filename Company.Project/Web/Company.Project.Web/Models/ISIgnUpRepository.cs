using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    public interface ISIgnUpRepository
    {
        SIgnUpDetails GetSIgnUpDetails(int Id);
        IEnumerable<SIgnUpDetails> GetAllSIgnUp();
        SIgnUpDetails Add(SIgnUpDetails sIgnUpDetails);
    }
}
