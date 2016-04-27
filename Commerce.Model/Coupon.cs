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
        public int CouponId { get; set; }

		[MaxLength(10)]
        public string CouponCode { get; set; }
        public int CouponTypeId { get; set; }

		[MaxLength(150)]
        public string CouponDescription { get; set; }
        public int AppliesToProductId { get; set; }
        public decimal Value { get; set; }
        public decimal MinSpend { get; set; }
        public bool MultipleUse { get; set; }
        public string AssignedTo { get; set; }


    }
}
