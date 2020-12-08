using FarmShop.ActionFilters.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace FarmShop.Controllers {
    public class HomeController : Controller {
        // [LoggedUser]        
        public IActionResult Index() {
            return View();
        }

        // login/logout actions
        [HttpGet]
        [LoggedUser]
        public IActionResult Logout() {
            this.HttpContext.Session.Remove("LoggedUserId");

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult Login() {
            if(this.HttpContext.Session.GetString("LoggedUserId") != null) {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
