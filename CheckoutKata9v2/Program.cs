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
            Checkout c = new Checkout(new ProductRepository());
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
