using FarmShop.ActionFilters.Auth;
using FarmShop.DataAccess;
using FarmShop.Entities;
using FarmShop.ViewModels.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

namespace FarmShop.Controllers {
    public class HomeController : Controller {
        [LoggedUser]        
        public IActionResult Index() {
            return View();
        }

        // login/logout actions
        [HttpGet]
        [LoggedUser]
        public IActionResult Logout() {
            this.HttpContext.Session.Clear();

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult Login() {
            if(this.HttpContext.Session.GetString("LoggedUsername") != null) {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM model) {
            if(!ModelState.IsValid) {
                return View(model);
            }
            
            UsersRepository repo = new UsersRepository();
            User user = repo.GetFirstOrDefault(u => u.Username == model.Username, true);

            if(user == null || !BC.Verify(model.Password, user.Password)) {
                ModelState.AddModelError("AuthFailed", "Wrong username or password");
                return View(model);
            }

            this.HttpContext.Session.SetString("LoggedUsername", user.Username);
            this.HttpContext.Session.SetString("LoggedUserRole", user.Role.Name);
            this.HttpContext.Session.SetString("LoggedUserId", user.Id.ToString());

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model) {
            if(!ModelState.IsValid) {
                RedirectToAction("Register", "Home");
            }

            UsersRepository usersRepo = new UsersRepository();
            User user = usersRepo.GetFirstOrDefault(u => u.Username == model.Username);

            if(user != null) {
                ModelState.AddModelError("RegisterFailed", "Username already taken");
                return View(model);
            }

            if(model.Password != model.ConfirmPassword) {
                ModelState.AddModelError("RegisterFailed", "Passwords must match");
                return View(model);
            }

            RolesRepository rolesRepo = new RolesRepository();
            Role role = rolesRepo.GetFirstOrDefault(r => r.Name == "User");

            user = new User(model.Username, model.Password, role.Id);
            usersRepo.Insert(user);

            this.HttpContext.Session.SetString("LoggedUsername", user.Username.ToString());
            this.HttpContext.Session.SetString("LoggedUserRole", role.Name);
            this.HttpContext.Session.SetString("LoggedUserId", user.Id.ToString());

            return RedirectToAction("Index", "Home");
        }
    }
}
