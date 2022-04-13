using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Route("Auth")]
    public class UserController : Controller
    {
        private UserService _UserService;

        public UserController(UserService UserService) => _UserService = UserService;
        
        [Route("")]
        [Route("~/")]
        [Route("~/index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user_login") != null) { return RedirectToAction("Menu"); }
            ViewData["msg"] = TempData["msg"];
            return View();
        }

        [HttpPost]
        [Route("~/login")]
        public IActionResult Login(string login, string password)
        {
            var user = _UserService.Login(login);
            if (user == null || user.Password != password) 
                { TempData["msg"] = "Wrong value"; return RedirectToAction("Index"); }
            else if(user.IsBlock)
                { TempData["msg"] = "You have been block"; return RedirectToAction("Index"); }

            HttpContext.Session.SetString("user_login", login);
            return RedirectToAction("menu");
        }

        [Route("~/menu")]
        public IActionResult Menu()
        {
            if (HttpContext.Session.GetString("user_login") == null) { return RedirectToAction("index"); }
            return View();
        }

        [Route("~/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user_login");
            return RedirectToAction("index");
        }
    }
}
