using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FarmShop.ActionFilters.Auth;
using FarmShop.DataAccess;
using FarmShop.Entities;
using FarmShop.ViewModels.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmShop.Controllers {
    [LoggedUser]
    public class OrdersController : Controller {
        [AdminRole]
        public IActionResult Index(IndexVM model) {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            OrdersRepository repo = new OrdersRepository();

            Expression<Func<Order, bool>> filter = p => (
            (model.Id == 0 || model.Id == p.Id) &&
            (string.IsNullOrEmpty(model.Username) || p.ParentUser.Username.Contains(model.Username)));

            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage, true);
            model.PagesCount = (int)Math.Ceiling((double)repo.Count(filter) / (double)model.ItemsPerPage);

            return View(model);
        }

        [HttpGet]
        [UserRole]
        public IActionResult Create() {
            CreateVM model = new CreateVM();
            ProductsRepository productsRepo = new ProductsRepository();
            model.Products = productsRepo.GetAll();
            model.Quantities = new int[model.Products.Count];
            model.Ids = new int[model.Products.Count];
            for (int i = 0; i < model.Ids.Length; i++) {
                model.Ids[i] = model.Products[i].Id;
            }
            return View(model);
        }

        [HttpPost]
        [UserRole]
        public IActionResult Create(CreateVM model) {

            UnitOfWork uow = new UnitOfWork();
            OrdersRepository ordersRepo = new OrdersRepository(uow);
            OrderProductsRepository opRepo = new OrderProductsRepository(uow);
            UsersRepository usersRepo = new UsersRepository(uow);
            ProductsRepository productsRepo = new ProductsRepository(uow);

            User loggedUsed = usersRepo.GetFirstOrDefault(u => u.Username == HttpContext.Session.GetString("LoggedUsername"));

            uow.BeginTransaction();
            Order order = new Order(DateTime.Now, loggedUsed.Id);

            try {

                ordersRepo.Insert(order);

                for (int i = 0; i < model.Ids.Length; i++) {

                    if (model.Quantities[i] > 0) {
                        OrderProduct op = new OrderProduct();
                        Product p = productsRepo.GetFirstOrDefault(pr => pr.Id == model.Ids[i]);

                        op.Order = order;
                        op.ProductId = p.Id;
                        op.PriceSold = p.CurrentPrice;
                        op.Quantity = model.Quantities[i];

                        opRepo.Insert(op);
                    }
                }
                uow.Commit();
            }
            catch(Exception) {
                uow.Rollback();
            }
            finally {
                uow.Dispose();
            }

            return RedirectToAction("My", "Orders");
        }

        [UserRole]
        public IActionResult My(IndexVM model) {
            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            OrdersRepository repo = new OrdersRepository();

            Expression<Func<Order, bool>> filter = p => (
            p.UserId.ToString() == HttpContext.Session.GetString("LoggedUserId") &&
            (model.Id == 0 || model.Id == p.Id) &&
            (string.IsNullOrEmpty(model.Username) || p.ParentUser.Username.Contains(model.Username)));

            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage, true);
            model.PagesCount = (int)Math.Ceiling((double)repo.Count(filter) / (double)model.ItemsPerPage);

            return View(model);
        }

        public IActionResult Details(int Id) {
            OrdersRepository repo = new OrdersRepository();
            OrderProductsRepository opRepo = new OrderProductsRepository();

            Order order = repo.GetById(Id, true);
            DetailsVM model = new DetailsVM();
            model.Order = order;

            model.OrderProducts = opRepo.GetAll(op => op.OrderId == order.Id,1,10,true);

            return View(model);
        }

        [AdminRole]
        public IActionResult Delete(int Id) {

            UnitOfWork uow = new UnitOfWork();

            OrdersRepository repo = new OrdersRepository(uow);
            OrderProductsRepository opRepo = new OrderProductsRepository(uow);

            uow.BeginTransaction();
            try { 
                Order order = repo.GetById(Id, true);
                List<OrderProduct> ops = opRepo.GetAll(op => order.Id == op.OrderId);

                foreach(OrderProduct op in ops) {
                    opRepo.Delete(op);
                }
                repo.Delete(order);
                uow.Commit();
            }
            catch(Exception) {
                uow.Rollback();
            }
            finally{
                uow.Dispose();
            }

            return RedirectToAction("Index", "Orders");
        }
    }
}
