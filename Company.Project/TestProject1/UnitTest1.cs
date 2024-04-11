using System;
using Xunit;
using Moq;
using Company.Project.Web.Controllers;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TestProject1
{
    
    public class UnitTest1
    {
        private const string ConnectionString = @"Data Source=IN-PG0352G0;Initial Catalog=bookevent;Trusted_Connection=true;Integrated Security=True;MultipleActiveResultSets=True";
        private MockRepository mockRepository;
        private readonly Mock<AppDbContext> db;
        private readonly Mock<UserManager<IdentityUser>> userManager;
        private readonly Mock<SignInManager<IdentityUser>> signInManager;

        public UnitTest1()
        {
          
            var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer(ConnectionString)
                    .Options;
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this.db = this.mockRepository.Create<AppDbContext>(options);
            this.userManager = this.mockRepository.Create<UserManager<IdentityUser>>(
                new Mock<IUserStore<IdentityUser>>().Object,
    new Mock<IOptions<IdentityOptions>>().Object,
    new Mock<IPasswordHasher<IdentityUser>>().Object,
    new IUserValidator<IdentityUser>[0],
    new IPasswordValidator<IdentityUser>[0],
    new Mock<ILookupNormalizer>().Object,
    new Mock<IdentityErrorDescriber>().Object,
    new Mock<IServiceProvider>().Object,
    new Mock<ILogger<UserManager<IdentityUser>>>().Object

                );
            this.signInManager = this.mockRepository.Create<SignInManager<IdentityUser>>(
                userManager.Object,
    Mock.Of<IHttpContextAccessor>(),
    Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),
    null, null, null, null

                );
        }

        private HomeController CreateController()
        {
            return new HomeController(
                this.db.Object,
                this.userManager.Object,
                this.signInManager.Object
                );
        }

        [Fact]
        public async void Login()
        {
            var controller = CreateController();

            Membership membership = new Membership
            {
                Email = "1234@gmail.com",
                Password = "Vijay",
            };
            var result = await controller.Login(membership);
            Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(result);

        }

        [Fact]
        public void SignUp()
        {
            var controller = CreateController();
            SIgnUpDetails model = new SIgnUpDetails
            {
                Id = 2,
                Name = "Test",
                Email = "123@gmail.com",
                Password = "Vijay"
            };
            var result = controller.SignUp(model);
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void EventForm()
        {
            var controller = CreateController();
            var result = controller.EventInfoForm();
            Assert.IsType<ViewResult>(result);
        }
    }
}
