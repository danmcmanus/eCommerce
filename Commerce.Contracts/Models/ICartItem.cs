using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface ICartItem
    {
        Guid CartId { get; set; }
        int CartItemId { get; set; }
        IProduct IProduct { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }

    }
}
