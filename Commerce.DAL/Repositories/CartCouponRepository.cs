using Commerce.DAL.Repositories;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class CartCouponRepository : RepositoryBase<CartCoupon>
    {
        public CartCouponRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
