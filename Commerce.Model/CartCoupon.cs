using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class CartCoupon : ICartCoupon
    {
        public int AppliesToCouponId { get; set; }
        public Guid CartId { get; set; }
        public int CartCouponId { get; set; }
        public decimal Value { get; set; }

        [MaxLength(10)]
        public string CouponCode { get; set; }

        [MaxLength(150)]
        public string CouponDescription { get; set; }
        public int CouponId { get; set; }
        public string CouponType { get; set; }
    }
}
