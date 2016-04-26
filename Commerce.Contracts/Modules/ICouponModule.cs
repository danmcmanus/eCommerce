using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Modules
{
    public interface ICouponModule
    {
        void ProcessCoupon(ICoupon coupon, ICart cart, ICartCoupon cartCoupon);
    }
}
