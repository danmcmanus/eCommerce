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
        ICollection<ICartItem> ICartItem { get; set; }
        ICollection<ICartCoupon> ICartCoupon { get; set; }
        DateTime date { get; set; }
        
        void AddCartItem(ICartItem item);
        void AddCartCoupon(ICartCoupon coupon);
        decimal CartTotal();
        decimal CartItemCount();
    }
}
