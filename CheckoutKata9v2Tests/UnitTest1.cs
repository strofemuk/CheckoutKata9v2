using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutKata9v2;

namespace CheckoutKata9v2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPrice()
        {
            ICheckout checkOut = new Checkout(new ProductRepository());

            Assert.AreEqual(.5M, checkOut.Scan("A"));
            Assert.AreEqual(.8M, checkOut.Scan("AB"));
            Assert.AreEqual(1.15M, checkOut.Scan("CDBA"));

            Assert.AreEqual(1.00M, checkOut.Scan("AA"));
            Assert.AreEqual(1.30M, checkOut.Scan("AAA"));
            Assert.AreEqual(1.80M, checkOut.Scan("AAAA"));
            Assert.AreEqual(2.30M, checkOut.Scan("AAAAA"));
            Assert.AreEqual(2.60M, checkOut.Scan("AAAAAA"));

            Assert.AreEqual(1.60M, checkOut.Scan("AAAB"));
            Assert.AreEqual(1.75M, checkOut.Scan("AAABB"));
            Assert.AreEqual(1.90M, checkOut.Scan("AAABBD"));
            Assert.AreEqual(1.90M, checkOut.Scan("DABABA"));
        }

        [TestMethod]
        public void TestIncremental()
        {
            ICheckout checkOut = new Checkout(new ProductRepository());

            Assert.AreEqual(checkOut.Total, 0.0M);
            Assert.AreEqual(0.5M, checkOut.Scan('A'));
            Assert.AreEqual(0.8M, checkOut.Scan('B'));
            Assert.AreEqual(1.3M, checkOut.Scan('A'));
            Assert.AreEqual(1.6M, checkOut.Scan('A'));
            Assert.AreEqual(1.75M, checkOut.Scan('B'));
        }
    }
}
