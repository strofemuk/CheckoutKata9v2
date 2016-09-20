using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2.PricingRules
{
    /// <summary>
    /// The default rule retrieves the price from the product repository.
    /// </summary>
    public class DefaultRule : ARule
    {
        private char _sku;
        private decimal _price;

        public override bool DoesSKUApply(ICheckout checkout)
        {
            if (checkout.SkuQueue.Length > 0)
            {
                _sku = checkout.SkuQueue[0];
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string SKUPattern
        {
            get { return "*"; }
        }

        public override decimal Price(IProductRepository productRepo)
        {
            _price = productRepo[_sku].UnitPrice;
            return _price;
        }

        public override string AddToReceipt
        {
            get { return string.Format("{0}\t|{1}\t|{2}", _sku, _price, string.Empty); }
        }
    }
}
