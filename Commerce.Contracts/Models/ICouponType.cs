using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface ICouponType
    {
        string Description { get; set; }
        string Type { get; set; }
        string CouponModule { get; set; }
        int CouponTypeId { get; set; }

    }
}
