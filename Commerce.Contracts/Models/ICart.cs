using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface ICart
    {
        Guid CartId { get; set; }
        ICollection<ICartItem> ICartItems { get;  }
        ICollection<ICartCoupon> ICartCoupons { get;  }
        DateTime date { get; set; }
        
        void AddCartItem(ICartItem item);
        void AddCartCoupon(ICartCoupon coupon);
        decimal CartTotal();
        decimal CartItemCount();
    }
}
