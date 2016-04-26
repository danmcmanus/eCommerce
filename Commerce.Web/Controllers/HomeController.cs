using Commerce.Contracts.Repository;
using Commerce.DAL;
using Commerce.DAL.Repositories;
using Commerce.DAL.Repository;
using Commerce.Model;
using Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Commerce.Web.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Cart> carts;
        CartService cartService;
        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Cart> carts)
        {
            this.customers = customers;
            this.products = products;
            this.carts = carts;
            cartService = new CartService(this.carts);
        }

        public ActionResult CartSummary()
        {
            var model = cartService.GetCart(this.HttpContext);

            return View(model.CartItems);
        }

        public ActionResult AddToCart(int id)
        {
            cartService.AddToCart(this.HttpContext, id, 1); //always add one to the basket

            return RedirectToAction("CartSummary");
        }
        public ActionResult Index()
        {

            var productList = products.GetAll();
            
            return View(productList);
        }

        public ActionResult Details(int id)
        {
            var product = products.GetById(id);

            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}