using CheckoutKata9v2.PricingRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2
{
    /// <summary>
    /// This represents the checkout function.
    /// In the ProcessScanned functions, the Checkout object is handed off
    /// to the ARule class's Interpret function thus calculating price and 
    /// building part of a receipt.
    /// </summary>
    public class Checkout : ICheckout
    {
        public Checkout(ProductRepository productDb, List<ARule> pricingRules)
        {
            ProductDb = productDb;
            PricingRules = pricingRules;
            Receipt = new StringBuilder();
        }

        /// <summary>
        /// Let's scan some products...BEEP...BEEP...BEEP
        /// This adds product's SKU to the processing queue.
        /// </summary>
        /// <param name="skus"></param>
        /// <returns></returns>
        public decimal Scan(string skus)
        {
            Total = 0.0m;
            Receipt = new StringBuilder();

            SkuQueue = skus;
            SortQ();
            ProcessScans();
            return Total;
        }

        /// <summary>
        /// Let's scan a product...BEEP...
        /// This adds a poduct's SKU to the processing queue.
        /// </summary>
        /// <param name="sku"></param>
        /// <returns></returns>
        public decimal Scan(char sku)
        {
            ScannedSkus += sku;
            return Scan(ScannedSkus);
        }

        /// <summary>
        /// This processes the processing queueu.  
        /// Using an interpreter pattern, each rule class adds to the price.
        /// </summary>
        public void ProcessScans()
        {
            foreach (ARule rule in PricingRules)
            {
                rule.Interpret(this);                
            }
        }

        /// <summary>
        /// The processing queue has to be soreted to be properly processed.
        /// </summary>
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

        /// <summary>
        /// The processed tootal.
        /// </summary>
        public decimal Total { get; set; }
        
        private string _scannedSkus = string.Empty;
        
        /// <summary>
        /// The SKUs that were scanned.
        /// </summary>
        public string ScannedSkus {
            get { return _scannedSkus; }
            private set
            {
                _scannedSkus = value;
                SkuQueue = value;
            } 
        }

        public string SkuQueue { get; set; }
        /// <summary>
        /// The receipt particulars built by the pricing rules.
        /// </summary>
        public StringBuilder Receipt { get; set; }
        public ProductRepository ProductDb { get; private set; }
        public List<ARule> PricingRules { get; private set; }
    }
}
