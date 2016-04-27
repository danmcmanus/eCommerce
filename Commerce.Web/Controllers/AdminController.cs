using Commerce.Contracts.Repositories;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Commerce.Web.Controllers
{
	public class AdminController : Controller
	{
		IRepositoryBase<Customer> customers;
		IRepositoryBase<Product> products;
		IRepositoryBase<CouponType> couponTypes;
		IRepositoryBase<Coupon> coupons;

		public AdminController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<CouponType> couponTypes, IRepositoryBase<Coupon> coupons)
		{
			this.customers = customers;
			this.products = products;
			this.coupons = coupons;
			this.couponTypes = couponTypes;
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult ProductList()
		{
			var model = products.GetAll();

			return View(model);
		}

		public ActionResult CreateProduct()
		{
			var model = new Product();

			return View(model);
		}

		public ActionResult CouponList()
		{
			var model = coupons.GetAll();

			return View(model);
		}

		public ActionResult CreateCoupon()
		{
			var model = new Coupon();
			ViewBag.couponTypes = couponTypes.GetAll();
			ViewBag.products = products.GetAll();

			return View(model);
		}

		[HttpPost]
		public ActionResult CreateCoupon(Coupon coupon)
		{


			coupons.Insert(coupon);
			coupons.Commit();

			return RedirectToAction("CouponList");
		}

		public ActionResult EditCoupon(int id)
		{
			Coupon coupon = coupons.GetById(id);


			return View(coupon);
		}

		[HttpPost]
		public ActionResult EditCoupon(Coupon coupon)
		{
			coupons.Update(coupon);
			coupons.Commit();

			return RedirectToAction("CouponList");
		}

		[HttpDelete]
		public ActionResult DeleteCoupon(int id)
		{
			coupons.Delete(id);

			return RedirectToAction("CouponList");
		}



		public ActionResult CouponTypeList()
		{
			var model = couponTypes.GetAll();

			return View(model);
		}

		public ActionResult CreateCouponType()
		{
			var model = new CouponType();

			return View(model);
		}

		[HttpPost]
		public ActionResult CreateCouponType(CouponType couponType)
		{

			couponTypes.Insert(couponType);
			couponTypes.Commit();

			return RedirectToAction("CouponTypeList");
		}

		public ActionResult EditCouponType(int id)
		{
			CouponType couponType = couponTypes.GetById(id);


			return View(couponType);
		}

		[HttpPost]
		public ActionResult EditCouponType(CouponType couponType)
		{
			couponTypes.Update(couponType);
			couponTypes.Commit();

			return RedirectToAction("CouponTypeList");
		}

		[HttpDelete]
		public ActionResult DeleteCouponType(int id)
		{
			couponTypes.Delete(id);

			return RedirectToAction("CouponTypeList");
		}

		[HttpPost]
		public ActionResult CreateProduct(Product product)
		{

			products.Insert(product);
			products.Commit();

			return RedirectToAction("ProductList");
		}

		public ActionResult EditProduct(int id)
		{
			Product product = products.GetById(id);


			return View(product);
		}

		[HttpPost]
		public ActionResult EditProduct(Product product)
		{
			products.Update(product);
			products.Commit();

			return RedirectToAction("ProductList");
		}
	}
}