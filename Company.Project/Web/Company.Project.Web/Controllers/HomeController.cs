using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Company.Project.Web.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Company.Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAccountService _accountService;
        private readonly ICommentService _commentService;
        private readonly IEventService _eventService;

        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IAccountService accountService, ICommentService commentService, IEventService eventService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _accountService = accountService;
            _commentService = commentService;
            _eventService = eventService;
        }


        public IActionResult Index()
        {
            var events = _eventService.GetEvents();
            CombinedModel cm = new CombinedModel();
            if (events == null)
            {
                return View(cm);
            }
            List<EventWithComment> eventWithComment = new List<EventWithComment>();
            Comment com = new Comment();
            foreach (EventTitles ev in events)
            {
                var comments = _eventService.GetCommentsByEventId(ev.Id);
                List<string> str = new List<string>();
                List<string> strCommenter = new List<string>();
                foreach (Comments c in comments)
                {
                    User user = _accountService.GetUserById(c.userId);
                    strCommenter.Add(user.Name);
                    str.Add(c.comment);
                }
                EventWithComment ewc = new EventWithComment
                {
                    Id = ev.Id,
                    title = ev.title,
                    date = (DateTime)ev.date,
                    location = ev.location,
                    startTime = ev.startTime,
                    duration = (int)ev.duration,
                    description = ev.description,
                    otherDetails = ev.otherDetails,
                    commenterName = strCommenter,
                    comments = str
                };
                eventWithComment.Add(ewc);
            }
            cm.eventWithComment = eventWithComment;
            cm.comment = com;
            return View(cm);
        }


        [HttpPost]
        public async Task<IActionResult> Index(CombinedModel model)
        {
            if (!ModelState.IsValid || model.comment.comment == null)
            {
                TempData["message"] = "Comment cannot be Null";
                return RedirectToAction("Index", "Home");
            }
            string email = User.Identity.Name;
            User user = _accountService.GetUserByEmail(email);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            string itemID = Request.Form["itemId"];

            Comments com = new Comments
            {
                eventId = int.Parse(itemID),
                userId = user.Id,
                comment = model.comment.comment
            };

            await _commentService.PostComment(com);
            return RedirectToAction("Index", "Home");
        }

        [Route("SignUp")]
        public ActionResult SignUp()
        {
            var model = new SIgnUpDetails();
            Debug.WriteLine(model);
            return View(model);
        }
        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SIgnUpDetails model)
        {
            if (model.Name == null || model.Email == null || model.Password == null)
            {
                TempData["message"] = "Name, Email or Password Can not be null";
                return View(model);
            }

            var isUserExist = _accountService.GetUserByEmail(model.Email);
            if (isUserExist != null)
            {
                ModelState.AddModelError("", "User Already exists");
                return View(model);
            }
            await _accountService.CreateUser(model);

            return RedirectToAction("Login", "Home");
        }
        [Route("Login")]
        public ActionResult Login()
        {
            var model = new Models.Membership();
            return View(model);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(Models.Membership model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Home");
            }
            if (model.Email == null || model.Password == null)
            {
                TempData["message"] = "Email or Password Can not be null";
                return View(model);
            }
            bool isUserExist = _accountService.LoginUser(model);
            if (!isUserExist)
            {
                ModelState.AddModelError("", "User Not Found");
                return View(model);
            }
            User x = _accountService.GetUserByEmail(model.Email);
            var userM = new IdentityUser { UserName = model.Email, Id = x.Id.ToString() };
            await userManager.CreateAsync(userM, model.Password);
           /* var isRoleExist = await roleManager.RoleExistsAsync("Admin");
            if (!isRoleExist)
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
            }

            var isInRole = await userManager.IsInRoleAsync(userM, "Admin");
            if (!isInRole)
            {

                await userManager.AddToRoleAsync(userM, "Admin");
            }*/
            await signInManager.SignInAsync(userM, isPersistent: false);
            return RedirectToAction("Index", "Home");

        }

        [Route("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Route("InvitedEvents")]
        [Authorize]
        public ActionResult InvitedEvents()
        {
            string id = User.Identity.Name;
            User use = _accountService.GetUserByEmail(id);
            int userId = use.Id;
            var invitedEvents = _eventService.GetInvitedEventByUserId(userId);
            CombinedModel cm = new CombinedModel();
            List<EventWithComment> eventWithComment = new List<EventWithComment>();
            Comment com = new Comment();
            foreach (var ie in invitedEvents)
            {
                EventTitles ev = _eventService.ViewEvent(ie.EventId);
                var comments = _eventService.GetCommentsByEventId(ev.Id);
                List<string> str = new List<string>();
                List<string> strCommenter = new List<string>();
                foreach (Comments c in comments)
                {
                    User user = _accountService.GetUserById(c.userId);
                    strCommenter.Add(user.Name);
                    str.Add(c.comment);
                }
                EventWithComment ewc = new EventWithComment
                {
                    Id = ev.Id,
                    title = ev.title,
                    date = (DateTime)ev.date,
                    location = ev.location,
                    startTime = ev.startTime,
                    duration = (int)ev.duration,
                    description = ev.description,
                    otherDetails = ev.otherDetails,
                    commenterName = strCommenter,
                    comments = str
                };
                eventWithComment.Add(ewc);
            }
            cm.eventWithComment = eventWithComment;
            cm.comment = com;
            return View(cm);
        }
        [Route("EventInfoForm")]
        [Authorize]
        public ActionResult EventInfoForm()
        {
            var model = new EventTitles();
            model.date = DateTime.Now;
            return View(model);
        }


        [Route("EventInfoForm")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EventInfoForm(EventTitles model)
        {
            if (model.title == null || model.location == null)
            {
                TempData["message"] = "Title and location cannot be empty";
                return View(model);
            }
            string id = User.Identity.Name;
            User use = _accountService.GetUserByEmail(id);
            int userId = use.Id;

            EventTitles e = new EventTitles
            {
                title = model.title,
                date = model.date,
                location = model.location,
                startTime = model.startTime,
                type = model.type,
                duration = model.duration,
                description = model.description,
                otherDetails = model.otherDetails,
                inviteByEmail = model.inviteByEmail,
                userId = userId
            };
            await _eventService.CreateEvent(e);
            int eventId = _eventService.GetMaxEventId();

            var s = model.inviteByEmail;
            if (s != null)
            {
                string[] str = s.Split(',');
                foreach (var st in str)
                {
                    User u = _accountService.GetUserByEmail(st);
                    if (u != null)
                    {
                        if (u.Id == userId) continue;
                        InvitedEvent initedEvent = new InvitedEvent
                        {
                            EventId = eventId,
                            userId = u.Id
                        };
                        await _eventService.CreateInvitedEvent(initedEvent);
                    }
                }
            }
            return View(new EventTitles());
        }

        [Route("MyEvent")]
        [Authorize]
        public ActionResult MyEvent()
        {
            string id = User.Identity.Name;
            User use = _accountService.GetUserByEmail(id);
            int userId = use.Id;
            var events = _eventService.MyEvents(userId);
            CombinedModel cm = new CombinedModel();
            List<EventWithComment> eventWithComment = new List<EventWithComment>();
            Comment com = new Comment();
            foreach (EventTitles ev in events)
            {
                var comments = _eventService.GetCommentsByEventId(ev.Id);
                List<string> str = new List<string>();
                List<string> strCommenter = new List<string>();
                foreach (Comments c in comments)
                {
                    User user = _accountService.GetUserById(c.userId);
                    strCommenter.Add(user.Name);
                    str.Add(c.comment);
                }
                EventWithComment ewc = new EventWithComment
                {
                    Id = ev.Id,
                    title = ev.title,
                    date = (DateTime)ev.date,
                    location = ev.location,
                    startTime = ev.startTime,
                    duration = (int)ev.duration,
                    description = ev.description,
                    otherDetails = ev.otherDetails,
                    commenterName = strCommenter,
                    comments = str
                };
                eventWithComment.Add(ewc);
            }
            cm.eventWithComment = eventWithComment;
            cm.comment = com;
            return View(cm);
        }




        [Route("EditEvent")]
        [Authorize]
        public ActionResult EditEvent(int Id)
        {
            if (Id < 0)
            {
                TempData["message"] = "Event Id can not be negetive";
                return RedirectToAction("Index", "Home");
            }
            string id = User.Identity.Name;
            User use = _accountService.GetUserByEmail(id);
            int userId = use.Id;
            User user = _accountService.GetUserById(userId);
            var isEvent = _eventService.isEventExist(userId, Id);
            if (isEvent == null && user.email != "myadmin@bookevents.com")
            {
                ModelState.AddModelError("", "You are trying to edit wrong post");
                return RedirectToAction("Index", "Home");
            }
            EventTitles model = _eventService.ViewEvent(Id);
            string s = model.startTime;
            string s1 = s.Split(' ')[0].Replace(":", "");
            int itemTime = int.Parse(s1);

            string s2 = DateTime.Now.ToString("HH:mm").Replace(".", "");
            int realTime = int.Parse(s2);


            if (model.date < DateTime.Now || (model.date == DateTime.Now && itemTime < realTime))
            {
                ModelState.AddModelError("", "User Not Found");
                TempData["message"] = "Can not edit, event was ended";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [Route("EditEvent")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditEvent(EventTitles model)
        {
            if (model.title == null || model.location == null)
            {
                TempData["message"] = "Title and location cannot be empty";
                return View(model);
            }
            string id = User.Identity.Name;
            User use = _accountService.GetUserByEmail(id);
            int userId = use.Id;
            User user = _accountService.GetUserById(userId);
            if (model.userId != userId && user.email != "myadmin@bookevents.com")
            {
                ModelState.AddModelError("", "You are trying to edit wrong post");
                return RedirectToAction("Index", "Home");
            }

            var invitedEvents = _eventService.GetInvitedEventsByEventId(model.Id);
            _eventService.RemoveInvitedEvents(invitedEvents);
            var s = model.inviteByEmail;
            if (s != null)
            {
                string[] str = s.Split(',');
                foreach (var st in str)
                {
                    User u = _accountService.GetUserByEmail(st);
                    if (u != null)
                    {
                        if (u.Id == model.userId) continue;
                        InvitedEvent initedEvent = new InvitedEvent
                        {
                            EventId = model.Id,
                            userId = u.Id
                        };
                        await _eventService.CreateInvitedEvent(initedEvent);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                await _eventService.UpdateEvent(model);
                if (user.email == "myadmin@bookevents.com") return RedirectToAction("AllEvent", "Home");
                return RedirectToAction("MyEvent", "Home");
            }
            return View(model);
        }



        [Route("AllEvent")]
        [Authorize(Roles = "Admin")]
        public ActionResult AllEvent()
        {
            string id = User.Identity.Name;
            if (id != "myadmin@bookevents.com")
            {
                ModelState.AddModelError("", "You are trying to edit wrong post");
                return RedirectToAction("MyEvent", "Home");
            }

            var events = _eventService.AllEvents();
            CombinedModel cm = new CombinedModel();
            if (events == null)
            {
                return View(cm);
            }
            List<EventWithComment> eventWithComment = new List<EventWithComment>();
            Comment com = new Comment();
            foreach (EventTitles ev in events)
            {
                var comments = _eventService.GetCommentsByEventId(ev.Id);
                List<string> str = new List<string>();
                List<string> strCommenter = new List<string>();
                foreach (Comments c in comments)
                {
                    User user = _accountService.GetUserById(c.Id);
                    strCommenter.Add(user.Name);
                    str.Add(c.comment);
                }
                EventWithComment ewc = new EventWithComment
                {
                    Id = ev.Id,
                    title = ev.title,
                    date = (DateTime)ev.date,
                    location = ev.location,
                    startTime = ev.startTime,
                    duration = (int)ev.duration,
                    description = ev.description,
                    otherDetails = ev.otherDetails,
                    commenterName = strCommenter,
                    comments = str
                };
                eventWithComment.Add(ewc);
            }
            cm.eventWithComment = eventWithComment;
            cm.comment = com;
            return View(cm);
        }

        [Route("Event")]
        public ActionResult Event(int Id)
        {
            if (Id < 0)
            {
                TempData["message"] = "Id can not be null";
                return RedirectToAction("Index", "Home");
            }
            CombinedModel cm = new CombinedModel();
            List<EventWithComment> eventWithComment = new List<EventWithComment>();
            Comment com = new Comment();
            EventTitles events = new EventTitles();
            if (User.Identity.IsAuthenticated)
            {
                string id = User.Identity.Name;
                User use = _accountService.GetUserByEmail(id);
                int userId = use.Id;
                User user1 = _accountService.GetUserById(userId);
                EventTitles isMyEvent = _eventService.isEventExist(userId, Id);

                var isInvitedEvent = _eventService.isInvitedEventExist(userId, Id);
                if (isMyEvent != null)
                {
                    events = isMyEvent;
                }
                else if (isInvitedEvent != null)
                {
                    events = _eventService.ViewEvent(Id);
                }
                else if (user1.email == "myadmin@bookevents.com")
                {
                    events = _eventService.ViewEvent(Id);
                }
                else
                {
                    events = _eventService.ViewPublicEvent(Id, true);
                }
            }
            else
            {
                events = _eventService.ViewPublicEvent(Id, true);
            }

            if (events == null)
            {
                ModelState.AddModelError("", "You are trying to edit wrong post");
                return RedirectToAction("Index", "Home");
            }

            var comments = _eventService.GetCommentsByEventId(Id);
            List<string> str = new List<string>();
            List<string> strCommenter = new List<string>();
            foreach (Comments c in comments)
            {
                User user = _accountService.GetUserById(c.userId);
                strCommenter.Add(user.Name);
                str.Add(c.comment);
            }
            EventWithComment ewc = new EventWithComment
            {
                Id = events.Id,
                title = events.title,
                date = (DateTime)events.date,
                location = events.location,
                startTime = events.startTime,
                duration = (int)events.duration,
                description = events.description,
                otherDetails = events.otherDetails,
                commenterName = strCommenter,
                comments = str
            };
            eventWithComment.Add(ewc);
            cm.eventWithComment = eventWithComment;
            cm.comment = com;
            return View(cm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
