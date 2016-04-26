using Commerce.DAL.Repository;
using Commerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.DAL.Repositories
{
    public class CartRepository : RepositoryBase<Cart>
    {
        public CartRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
