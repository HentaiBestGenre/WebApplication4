using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication4.Data;
using WebApplication4.Models;
using WebApplication4.Services;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class EditController : Controller
    {
        private GetUsersCBService _GetUsersCBService;
        private UserService _UserService;
        private readonly ApplicationDbContext _db;
        public EditController(GetUsersCBService GetUsersCBService, ApplicationDbContext db, UserService UserService)
        {
            _GetUsersCBService = GetUsersCBService;
            _UserService = UserService;
            _db = db;
        }

        [Route("~/Edit")]
        [Route("~/Edit/")]
        [Route("~/Edit/index")]
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("user_login") == null) { return Redirect("/index"); }
            if (HttpContext.Session.GetString("user_login") == null) { return Redirect("/"); }
            List<UserCheckBox> UsersCB = _GetUsersCBService.GetUsersCB();
            return View(UsersCB);
        }

        [HttpPost]
        public ActionResult Edit(List<UserCheckBox> UsersCB, string delete, string block, string unblock)
        {
            foreach (var user in UsersCB)
            {
                if (user.IsCheck)
                {
                    User u = _db.Users.FirstOrDefault(c => c.Id == user.Id);
                    if (delete != null) { Console.WriteLine("Delete"); Delete(u); }
                    else if(block != null) { Console.WriteLine("Block"); Block(u); }
                    else if(unblock != null) { Console.WriteLine("UnBlock"); UnBlock(u); }
                }
            }
            _db.SaveChanges();
            if (ChackState()) { return Redirect("~/logout"); }
            return Redirect("Index");
        }

        public bool ChackState()
        {
            User user = _UserService.Login(HttpContext.Session.GetString("user_login"));
            if (user == null || user.IsBlock) { return true; }
            return false;
        }

        public void Delete(User user)
        {
            _db.Users.Remove(user);
        }

        public void Block(User user)
        {
            user.IsBlock = true;
            _db.Users.Update(user);
        }
        public void UnBlock(User user)
        {
            user.IsBlock = false;
            _db.Users.Update(user);
        }
    }
}
