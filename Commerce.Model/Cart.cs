using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Cart : ICart
    {
		private List<CartItem> _cartItems;
		private List<CartCoupon> _cartCoupons;
		public Guid CartId { get; set; }
        public DateTime date { get; set; }

        public Cart()
        {
            this.CartItems = new List<CartItem>();
			this.CartCoupons = new List<CartCoupon>();
			
        }

		public decimal CartTotal()
		{
			decimal? total = (from item in CartItems
							 select (int?)item.Quantity *
							 item.Product.Price).Sum();

			return total ?? decimal.Zero;
		}

		public decimal CartItemCount()
		{
			return _cartItems.Count();
		}

        public virtual ICollection<ICartItem> ICartItems { get { return _cartItems.ConvertAll(i => (ICartItem)i); } }
		public virtual ICollection<CartItem> CartItems { get { return _cartItems;} set {_cartItems = value.ToList(); } }
		public virtual ICollection<ICartCoupon> ICartCoupons { get { return _cartItems.ConvertAll(i => (ICartCoupon)i);} }
		public virtual ICollection<CartCoupon> CartCoupons {get { return _cartCoupons;} set { _cartCoupons = value.ToList();} }

		public void AddCartItem(ICartItem item)
		{
			_cartItems.Add((CartItem)item);
		}

		public void AddCartCoupon(ICartCoupon coupon)
		{
			_cartCoupons.Add((CartCoupon) coupon);
		}
    }
}
