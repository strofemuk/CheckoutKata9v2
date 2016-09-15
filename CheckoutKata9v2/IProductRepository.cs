using System;
using System.Collections.Generic;
namespace CheckoutKata9v2
{
    public interface IProductRepository : IList<Product>
    {
        Product this[char sku] { get; }
    }
}
