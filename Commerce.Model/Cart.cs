using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Model
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public DateTime date { get; set; }

        public Cart()
        {
            this.CartItems = new List<CartItem>();
        }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
