using CheckoutKata9v2.PricingRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ARule> pricingRules = new List<ARule>();
            pricingRules.Add(new SkuA());
            pricingRules.Add(new SkuB());
            pricingRules.Add(new DefaultRule());

            Checkout c = new Checkout(new ProductRepository(), pricingRules);
            c.Scan("AAA");
            Console.WriteLine(c.Total);

            c.Scan("AAAA");
            Console.WriteLine(c.Total);

            c.Scan("AAABBA");
            Console.WriteLine(c.Total);

            Console.WriteLine(c.Receipt);

            Console.ReadKey();
        }
    }
}
