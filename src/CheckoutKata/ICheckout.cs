namespace CheckoutKata;

public interface ICheckout
{
    decimal Total();
    void Scan(string sku);
}