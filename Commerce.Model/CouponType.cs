using Commerce.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class CouponType : ICouponType
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string CouponModule { get; set; }
        public int CouponTypeId { get; set; }
    }
}
