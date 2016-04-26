using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface ICoupon
    {
        int AppliesToProductId { get;set; }
        string AssignedTo {get;set; }
        decimal MinSpend {get;set; }
        bool MultipleUse {get;set; }
        decimal Value {get;set; }
        string CouponCode {get;set; }
        string CouponDescription {get;set; }
        int CouponId {get;set; }
        int CouponTypeId {get;set; }

    }
}
