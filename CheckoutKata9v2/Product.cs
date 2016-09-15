using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2
{
    public enum UnitOfMeasure
    {
        Each = 0,
        Pound = 1,
        Kilo = 2,
        Ton = 4,
    }

    public class Product
    {
        public string Description { get; set; }
        public char SKU { get; set; }
        public decimal UnitPrice { get; set; }
        public UnitOfMeasure UoM { get; set; }
    }
}
