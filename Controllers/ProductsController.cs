using System;
using System.Linq.Expressions;
using FarmShop.ActionFilters.Auth;
using FarmShop.DataAccess;
using FarmShop.Entities;
using FarmShop.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;

namespace FarmShop.Controllers {
    [AdminRole]
    public class ProductsController : Controller {
        public IActionResult Index(IndexVM model) {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            ProductsRepository repo = new ProductsRepository();

            Expression<Func<Product, bool>> filter = p => (
            (model.Id == 0 || model.Id == p.Id) &&
            (model.Price == "" || model.Price == null || p.CurrentPrice >= decimal.Parse(model.Price)) &&
            (string.IsNullOrEmpty(model.Name) || p.Name.Contains(model.Name)));

            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage);
            model.PagesCount = (int)Math.Ceiling((double)repo.Count(filter) / (double)model.ItemsPerPage);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model) {

            ProductsRepository repo = new ProductsRepository();
            Product p = new Product(model.Name, decimal.Parse(model.Price));
            repo.Insert(p);

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Delete(int Id) {
            ProductsRepository repo = new ProductsRepository();
            Product p = repo.GetById(Id);
            p.IsDeleted = true;
            repo.Update(p);

            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public IActionResult Edit(int Id) {
            ProductsRepository repo = new ProductsRepository();
            Product p = repo.GetById(Id);
            EditVM model = new EditVM(p);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model) {
            ProductsRepository repo = new ProductsRepository();
            Product p = repo.GetById(model.Id);
            p.Name = model.Name;
            p.CurrentPrice = decimal.Parse(model.Price);

            repo.Update(p);

            return RedirectToAction("Index", "Products");
        }

        public IActionResult Recover(int Id) {
            ProductsRepository repo = new ProductsRepository();
            Product p = repo.GetById(Id);
            p.IsDeleted = false;
            repo.Update(p);
            return RedirectToAction("Index", "Products");
        }
    }
}
