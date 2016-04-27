using Commerce.Contracts.Models;
using Commerce.Contracts.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Modules.Coupons.PercentOff
{
	public class Coupon_Module : ICouponModule
	{
		public void ProcessCoupon(ICoupon coupon, ICart cart, ICartCoupon cartCoupon)
		{
			if (coupon.MinSpend < cart.CartTotal())
			{
				cartCoupon.Value = coupon.Value * (cart.CartTotal() / 100);
				cartCoupon.CouponCode = coupon.CouponCode;
				cartCoupon.CouponCode = coupon.CouponDescription;
				cartCoupon.CouponId = coupon.CouponId;
				cart.AddCartCoupon(cartCoupon);
			}
		}
	}
}
