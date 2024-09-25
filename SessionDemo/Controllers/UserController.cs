using Microsoft.AspNetCore.Mvc;
using SessionDemo.Models;

namespace SessionDemo.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(User user)
        {
            HttpContext.Session.SetString("user",user.Name);
            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult Logout() { 
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }
    }
}
