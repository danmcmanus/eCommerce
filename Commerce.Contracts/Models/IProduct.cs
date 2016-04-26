using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Contracts.Models
{
    public interface IProduct
    {
        decimal CostPrice { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }
        int ProductId { get; set; }
    }
}
