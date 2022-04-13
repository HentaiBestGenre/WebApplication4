using Microsoft.AspNetCore.Mvc;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class RegistrationController : Controller
    {
        private UserService _UserService;

        public RegistrationController(UserService UserService) => _UserService = UserService;


        [Route("/registration/")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user_login") != null) { return Redirect("/menu"); }
            ViewData["msg"] = TempData["msg"];
            return View();
        }

        [HttpPost]
        public IActionResult Reg(string login, string password)
        {
            var row = _UserService.Login(login);
            if (row != null) { TempData["msg"] = "This user already exists!"; return RedirectToAction("Index"); }
            _UserService.Reg(login, password);
            return Redirect("~/");
        }
    }
}
