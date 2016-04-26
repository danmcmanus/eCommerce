using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Coupon : ICoupon
    {
        public int AppliesToProductId { get; set; }
        public string AssignedTo { get; set; }
        public decimal MinSpend { get; set; }
        public bool MultipleUse { get; set; }
        public decimal Value { get; set; }

        [MaxLength(10)]
        public string CouponCode { get; set; }

        [MaxLength(150)]
        public string CouponDescription { get; set; }
        public int CouponId { get; set; }
        public int CouponTypeId { get; set; }
    }
}
