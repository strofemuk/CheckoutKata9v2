using CheckoutKata9v2.PricingRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2
{
    public class Checkout : ICheckout
    {
        public Checkout(ProductRepository productDb)
        {
            ProductDb = productDb;
            Receipt = new StringBuilder();
        }

        public decimal Scan(string skus)
        {
            Total = 0.0m;
            Receipt = new StringBuilder();

            SkuQueue = skus;
            SortQ();
            ProcessScans();
            return Total;
        }


        public decimal Scan(char sku)
        {
            ScannedSkus += sku;
            return Scan(ScannedSkus);
        }

        public void ProcessScans()
        {
            List<ARule> rules = new List<ARule>();
            rules.Add(new SkuA());
            rules.Add(new SkuB());
            rules.Add(new DefaultRule());

            foreach (ARule rule in rules)
            {
                rule.Interpret(this,ProductDb);                
            }
        }

        private void SortQ()
        {
            char[] charQ = SkuQueue.ToCharArray();
            Array.Sort(charQ);
            SkuQueue = string.Empty;    
            foreach (char c in charQ)
            {
                SkuQueue += c;
            }
        }

        public decimal Total { get; set; }
        
        private string _scannedSkus = string.Empty;
        
        public string ScannedSkus {
            get { return _scannedSkus; }
            private set
            {
                _scannedSkus = value;
                SkuQueue = value;
            } 
        }

        public string SkuQueue { get; set; }
        public StringBuilder Receipt { get; set; }
        public ProductRepository ProductDb { get; private set; }
    }
}
