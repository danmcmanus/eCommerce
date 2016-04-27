using Commerce.Contracts.Models;
using Commerce.Contracts.Modules;
using Commerce.Contracts.Repositories;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Commerce.Services
{
    public class CartService
    {
        IRepositoryBase<Cart> carts;
        private IRepositoryBase<Coupon> coupons;
        private IRepositoryBase<CouponType> couponTypes;
        private IRepositoryBase<CartCoupon> cartCoupons;

        public const string CartSessionName = "eCommerceCart";

        public CartService(IRepositoryBase<Cart> carts, IRepositoryBase<Coupon> coupons, IRepositoryBase<CartCoupon> cartCoupons, IRepositoryBase<CouponType> couponTypes)
        {
            this.carts = carts;
            this.coupons = coupons;
            this.cartCoupons = cartCoupons;
            this.couponTypes = couponTypes;
        }

        private Cart createNewCart(HttpContextBase httpContext)
        {
            //create a new cart.

            //first create a new cookie.
            HttpCookie cookie = new HttpCookie(CartSessionName);
            //now create a new cart and set the creation date.
            Cart cart = new Cart();
            cart.date = DateTime.Now;
            cart.CartId = Guid.NewGuid();

            //add and persist in the dabase.
            carts.Insert(cart);
            carts.Commit();

            //add the cart id to a cookie
            cookie.Value = cart.CartId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return cart;
        }

        public bool AddToCart(HttpContextBase httpContext, int productId, int quantity)
        {
            bool success = true;

            Cart cart = GetCart(httpContext);
            CartItem item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
            {
                item = new CartItem()
                {
                    CartId = cart.CartId,
                    ProductId = productId,
                    Quantity = quantity
                };
                cart.AddCartItem(item);
            }
            else
            {
                item.Quantity = item.Quantity + quantity;
            }
            carts.Commit();

            return success;
        }

        public Cart GetCart(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(CartSessionName);
            Cart cart;

            Guid cartId;

            if (cookie != null)
            {

                if (Guid.TryParse(cookie.Value, out cartId))
                {
                    cart = carts.GetById(cartId);
                }
                else
                {
                    cart = createNewCart(httpContext);
                }
            }
            else
            {
                cart = createNewCart(httpContext);
            }

            return cart;
        }

        public void AddCoupon(string couponCode, HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext);
            Coupon coupon = coupons.GetAll().FirstOrDefault(v => v.CouponCode == couponCode);

            if (coupon != null)
            {
                CouponType couponType = couponTypes.GetById(coupon.CouponTypeId);
                if (couponType != null)
                {
                    CartCoupon cartCoupon = new CartCoupon();
                    if (couponType.Type == "MoneyOff")
                    {
                        MoneyOff(coupon, cart, cartCoupon);
                    }
                    if (couponType.Type == "PercentOff")
                    {
                        PercentOff(coupon, cart, cartCoupon);
                    }

                    carts.Commit();
                }
            }

        }

        public void MoneyOff(Coupon coupon, Cart cart, CartCoupon cartCoupon)
        {
            decimal cartTotal = cart.CartTotal();
            if (coupon.MinSpend < cartTotal)
            {
                cartCoupon.Value = coupon.Value * -1;
                cartCoupon.CouponCode = coupon.CouponCode;
                cartCoupon.CouponDescription = coupon.CouponDescription;
                cartCoupon.CouponId = coupon.CouponId;
                cart.AddCartCoupon(cartCoupon);
            }

        }


        public void PercentOff(Coupon coupon, Cart cart, CartCoupon cartCoupon)
        {
            if (coupon.MinSpend > cart.CartTotal())
            {
                cartCoupon.Value = (coupon.Value * (cart.CartTotal() / 100)) * -1;
                cartCoupon.CouponCode = coupon.CouponCode;
                cartCoupon.CouponDescription = coupon.CouponDescription;
                cartCoupon.CouponId = coupon.CouponId;
                cart.AddCartCoupon(cartCoupon);
            }


        }
    }
}

