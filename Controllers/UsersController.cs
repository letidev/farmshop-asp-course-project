using FarmShop.ActionFilters.Auth;
using FarmShop.DataAccess;
using FarmShop.Entities;
using FarmShop.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace FarmShop.Controllers {
    
    [AdminRole]
    public class UsersController : Controller {

        public IActionResult Index(IndexVM model) {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            UsersRepository repo = new UsersRepository();

            Expression<Func<User, bool>> filter = u => !u.IsDeleted && (string.IsNullOrEmpty(model.Username) || u.Username.Contains(model.Username));

            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage);
            model.PagesCount = (int)Math.Ceiling((double)repo.Count(filter) / (double)model.ItemsPerPage);

            return View(model);
        }

        public IActionResult Delete(int Id) {
            UsersRepository repo = new UsersRepository();
            User user = repo.GetById(Id);
            user.IsDeleted = true;
            repo.Update(user);

            return RedirectToAction("Index", "Users");
        }
    }
}
