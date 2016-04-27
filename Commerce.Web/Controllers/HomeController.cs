using Commerce.Contracts.Repositories;
using Commerce.DAL;
using Commerce.DAL.Repositories;
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
		IRepositoryBase<Coupon> coupons;
		IRepositoryBase<CouponType> couponTypes;
		IRepositoryBase<CartCoupon> cartCoupons;

        CartService cartService;

        //public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Cart> carts, IRepositoryBase<Coupon> coupons, IRepositoryBase<CouponType> couponTypes, IRepositoryBase<CartCoupon> cartCoupons)
        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Cart> carts, IRepositoryBase<Coupon> coupons, IRepositoryBase<CartCoupon> cartCoupons, IRepositoryBase<CouponType> couponTypes)
        {
            this.customers = customers;
            this.products = products;
            this.carts = carts;
			this.coupons = coupons;
			this.couponTypes = couponTypes;
			this.cartCoupons = cartCoupons;
            cartService = new CartService(this.carts,this.coupons, this.cartCoupons,this.couponTypes);
        }

        public ActionResult CartSummary()
        {
            var model = cartService.GetCart(this.HttpContext);

            return View(model);
        }

        public ActionResult AddToCart(int id)
        {
            Cart cart = cartService.GetCart(this.HttpContext);
            cartService.AddToCart(this.HttpContext,id,1); //always add one to the cart
            
			
            return RedirectToAction("CartSummary");
        }

		public ActionResult AddCartCoupon(string couponCode)
		{
			cartService.AddCoupon(couponCode,this.HttpContext);

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