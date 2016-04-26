using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface ICartCoupon
    {
        int AppliesToCouponId { get; set; }
        Guid CartId { get; set; }
        int CartCouponId { get; set; }
        decimal Value { get; set; }
        string CouponCode { get; set; }
        string CouponDescription { get; set; }
        int CouponId { get; set; }
        string CouponType { get; set; }

    }
}
