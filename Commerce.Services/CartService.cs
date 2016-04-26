using Commerce.Contracts.Repository;
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
        public const string CartSessionName = "CommerceCart";
        public CartService(IRepositoryBase<Cart> carts)
        {
            this.carts = carts;
        }

        private Cart createNewCart(HttpContextBase httpContext)
        {
            //create a new cart
            //first create a new cookie.
            HttpCookie cookie = new HttpCookie(CartSessionName);
            //now create a new cart and set the creation date.
            Cart cart = new Cart();
            cart.date = DateTime.Now;
            cart.CartId = Guid.NewGuid();

            carts.Insert(cart);
            carts.Commit();

            //add cart id to a cookie
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
                cart.CartItems.Add(item);
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
        
    }
}
