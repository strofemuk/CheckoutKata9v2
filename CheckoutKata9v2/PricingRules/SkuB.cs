using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2.PricingRules
{
    public class SkuB : ARule
    {
        /// <summary>
        /// SKU = B, Quantity = 2, price = .45
        /// </summary>
        /// <param name="checkout"></param>
        /// <returns></returns>
        public override bool DoesSKUApply(ICheckout checkout)
        {
            return checkout.SkuQueue.StartsWith(SKUPattern);
        }

        public override string SKUPattern
        {
            get { return "BB"; }
        }

        public override decimal Price(IProductRepository productRepo)
        {
            return SpecialPrice;
        }

        public decimal SpecialPrice
        {
            get { return 0.45M; }
        }

        public override string AddToReceipt
        {
            get { return string.Format("{0}\t|{1}\t|{2}", "B", SpecialPrice, "2 For .45"); }
        }
    }
}
