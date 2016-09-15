using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2
{
    public class ProductRepository : List<Product>, IProductRepository
    {
        public ProductRepository()
        {
            this.Add(new Product() { SKU = 'A', Description = "Drink", UnitPrice = 0.50M, UoM = UnitOfMeasure.Each });
            this.Add(new Product() { SKU = 'B', Description = "Bread", UnitPrice = 0.30M, UoM = UnitOfMeasure.Each });
            this.Add(new Product() { SKU = 'C', Description = "Bagel", UnitPrice = 0.20M, UoM = UnitOfMeasure.Each });
            this.Add(new Product() { SKU = 'D', Description = "Toast", UnitPrice = 0.15M, UoM = UnitOfMeasure.Each });
            this.Add(new Product() { SKU = 'E', Description = "Steak", UnitPrice = 6.99M, UoM = UnitOfMeasure.Each });
        }

        public Product this[char sku]
        {
            get
            {
                return this.Where(p => p.SKU == sku).FirstOrDefault();
            }
        }
    }
}
