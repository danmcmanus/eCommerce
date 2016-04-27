using Commerce.Contracts.Repositories;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class CouponTypeRepository : RepositoryBase<CouponType>
    {
        public CouponTypeRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
