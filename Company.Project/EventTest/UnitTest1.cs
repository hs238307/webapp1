using Xunit;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Identity;
using Company.Project.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;
using Microsoft.Extensions.Options;


namespace EventTest
{

    public class TestDatabaseFixture : IdentityDbContext
    {
        private const string ConnectionString = @"Data Source=IN-BWZC5S3;Initial Catalog=bookevent ; Trusted_Connection=true;Integrated Security=True;MultipleActiveResultSets=True";
        public DbSet<User> User { get; set; }
        public AppDbContext CreateContext()
            => new AppDbContext(
                new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }


    public class UnitTest1 : IClassFixture<TestDatabaseFixture>
    {
        private readonly Mock<UserManager<IdentityUser>> userManager1;
        private readonly Mock<SignInManager<IdentityUser>> signInManager1;
        private MockRepository mockRepository;

        public TestDatabaseFixture Fixture { get; }
        public UnitTest1(TestDatabaseFixture fixture)
        {
            Fixture = fixture;
            this.mockRepository = new MockRepository(MockBehavior.Default);
            this.userManager1 = this.mockRepository.Create<UserManager<IdentityUser>>(
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
            this.signInManager1 = this.mockRepository.Create<SignInManager<IdentityUser>>(
                userManager1.Object,
                 Mock.Of<IHttpContextAccessor>(),
                 Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),
                 null, null, null, null
                );
        }

        [Fact]
        public void SignUp()
        {
            using var context = Fixture.CreateContext();
            var controller = new HomeController(context, userManager1.Object, signInManager1.Object);
            SIgnUpDetails model = new SIgnUpDetails
            {
                Id = 1,
                Name = "hemant",
                Email = "123@gmail.com",
                Password = "123"
            };
            var result = controller.SignUp(model);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void Login()
        {
            using var co = Fixture.CreateContext();
            var controller = new HomeController(co, userManager1.Object, signInManager1.Object);

            Membership membership = new Membership
            {
                Email = "123@gmail.com",
                Password = "123"
            };
            var result = await controller.Login(membership);
            Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(result);
        }

        [Fact]
        public void EventForm()
        {
            using var context = Fixture.CreateContext();
            var controller = new HomeController(context, userManager1.Object, signInManager1.Object);
            var result = controller.EventInfoForm();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index()
        {
            using var context = Fixture.CreateContext();
            var controller = new HomeController(context, userManager1.Object, signInManager1.Object);
            var result = controller.Index();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void AddEventTest()
        {
            using var context = Fixture.CreateContext();
            var controller = new HomeController(context, userManager1.Object, signInManager1.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "123@gmail.com")
            }, "mock"));
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
            var result = controller.InvitedEvents();
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Event()
        {
            using var context = Fixture.CreateContext();
            var controller = new HomeController(context, userManager1.Object, signInManager1.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "123@gmail.com")
            }, "mock"));
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
            var result = controller.Event(10);
            Assert.IsType<ViewResult>(result);
        }
    }

}
