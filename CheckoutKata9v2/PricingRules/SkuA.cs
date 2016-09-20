using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2.PricingRules
{
    /// <summary>
    /// SKU = a, Quantity = 3, price = 1.30
    /// </summary>
    public class SkuA : ARule
    {
        public override bool DoesSKUApply(ICheckout checkout)
        {
            return checkout.SkuQueue.StartsWith(SKUPattern);
        }

        public override string SKUPattern
        {
            get { return "AAA"; }
        }

        public override decimal Price(IProductRepository productRepo)
        {
            return SpecialPrice;
        }

        public decimal SpecialPrice { get { return 1.30M; } }

        public override string AddToReceipt
        {
            get { return string.Format("{0}\t|{1}\t|{2}", "A", SpecialPrice, "3 For 1.30"); }
        }
    }
}
