using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Interfaces
{
    public interface IAccountService
    {
        Task CreateUser(SIgnUpDetails signUpDetails);
        public bool LoginUser(Membership membership);
        User GetUserById(int userId);
        User GetUserByEmail(string email);

        Task SignOut();
    }
}
