using Company.Project.Web.Interfaces;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountService _accountService;
        private readonly AppDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(AppDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._db = db;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task CreateUser(SIgnUpDetails signUpDetails)
        {
            User user = new User
            {
                email = signUpDetails.Email,
                Name = signUpDetails.Name,
                password = signUpDetails.Password
            };
            await _db.User.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public User GetUserByEmail(string email)
        {
            User user = _db.User.FirstOrDefault(u => u.email == email);
            return user;
        }

        public User GetUserById(int userId)
        {
            User user = _db.User.FirstOrDefault(u => u.Id == userId);
            return user;
        }

        public bool LoginUser(Membership membership)
        {
            bool isExist = _db.User.Any(u => u.email == membership.Email && u.password == membership.Password);
            return isExist;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
