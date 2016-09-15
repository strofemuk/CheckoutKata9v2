using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata9v2.PricingRules
{
    public abstract class ARule
    {
        public void Interpret(ICheckout checkout, IProductRepository productRepo)
        {
            bool repeat = true;

            while (repeat)
            {
                if (DoesSKUApply(checkout))
                {
                    checkout.Total += Price(productRepo);
                    checkout.SkuQueue = checkout.SkuQueue.Substring(SKUPattern.Length);
                    checkout.Receipt.AppendLine(AddToReceipt);
                }
                else
                {
                    repeat = false;
                }
            }
        }

        public abstract bool DoesSKUApply(ICheckout checkout);
        public abstract string SKUPattern { get; }
        public abstract decimal Price(IProductRepository productRepo);
        public abstract string AddToReceipt { get; }
    }
}
