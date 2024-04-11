using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Interfaces
{
    public interface ICommentService
    {
        Task PostComment(Comments comments);
    }
}
