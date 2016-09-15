using System;
namespace CheckoutKata9v2
{
    public interface ICheckout
    {
        void ProcessScans();
        ProductRepository ProductDb { get; }
        System.Text.StringBuilder Receipt { get; set; }
        decimal Scan(char sku);
        decimal Scan(string skus);
        string SkuQueue { get; set; }
        decimal Total { get; set; }

    }
}
