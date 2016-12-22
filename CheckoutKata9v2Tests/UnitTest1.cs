using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata9v2;
using System.Collections.Generic;
using CheckoutKata9v2.PricingRules;

namespace CheckoutKata9v2Tests
{
    /*
     * This week, let’s implement the code for a supermarket checkout that calculates the total price of a number of items. 
     * In a normal supermarket, things are identified using Stock Keeping Units, or SKUs. In our store, we’ll use individual 
     * letters of the alphabet (A, B, C, and so on). Our goods are priced individually. In addition, some items are 
     * multipriced: buy n of them, and they’ll cost you y cents. For example, item ‘A’ might cost 50 cents individually, 
     * but this week we have a special offer: buy three ‘A’s and they’ll cost you $1.30. In fact this week’s prices are:

          Item   Unit      Special
                 Price     Price
          --------------------------
            A     50       3 for 130
            B     30       2 for 45
            C     20
            D     15
     
     * Our checkout accepts items in any order, so that if we scan a B, an A, and another B, we’ll recognize the two B’s and 
     * price them at 45 (for a total price so far of 95). Because the pricing changes frequently, we need to be able to pass 
     * in a set of pricing rules each time we start handling a checkout transaction.

     * The interface to the checkout should look like:

        co = CheckOut.new(product_repository, pricing_rules)
        total = co.scan(item)
        total += co.scan(item)
    
     * There are lots of ways of implementing this kind of algorithm; if you have time, experiment with several.

     * Objectives of the Kata
     * To some extent, this is just a fun little problem. But underneath the covers, it’s a stealth exercise in decoupling. 
     * The challenge description doesn’t mention the format of the pricing rules. How can these be specified in such a way 
     * that the checkout doesn’t know about particular items and their pricing strategies? How can we make the design flexible 
     * enough so that we can add new styles of pricing rule in the future?
     * */

    [TestClass]
    public class UnitTest1
    {
        private List<ARule> _pricingRules = new List<ARule>();
        private ICheckout _checkOut;

        [TestInitialize]
        public void TestInit()
        {
            _pricingRules.Clear();
            _pricingRules.Add(new SkuA());
            _pricingRules.Add(new SkuB());
            _pricingRules.Add(new DefaultRule());

            _checkOut = new Checkout(new ProductRepository(), _pricingRules);
        }

        [TestMethod]
        public void TestPrice()
        {
            Assert.AreEqual(.5M, _checkOut.Scan("A"));
            Assert.AreEqual(.8M, _checkOut.Scan("AB"));
            Assert.AreEqual(1.15M, _checkOut.Scan("CDBA"));

            Assert.AreEqual(1.00M, _checkOut.Scan("AA"));
            Assert.AreEqual(1.30M, _checkOut.Scan("AAA"));
            Assert.AreEqual(1.80M, _checkOut.Scan("AAAA"));
            Assert.AreEqual(2.30M, _checkOut.Scan("AAAAA"));
            Assert.AreEqual(2.60M, _checkOut.Scan("AAAAAA"));

            Assert.AreEqual(1.60M, _checkOut.Scan("AAAB"));
            Assert.AreEqual(1.75M, _checkOut.Scan("AAABB"));
            Assert.AreEqual(1.90M, _checkOut.Scan("AAABBD"));
            Assert.AreEqual(1.90M, _checkOut.Scan("DABABA"));
        }

        [TestMethod]
        public void TestIncremental()
        {
            Assert.AreEqual(_checkOut.Total, 0.0M);
            Assert.AreEqual(0.5M, _checkOut.Scan('A'));
            Assert.AreEqual(0.8M, _checkOut.Scan('B'));
            Assert.AreEqual(1.3M, _checkOut.Scan('A'));
            Assert.AreEqual(1.6M, _checkOut.Scan('A'));
            Assert.AreEqual(1.75M, _checkOut.Scan('B'));
        }
    }
}
