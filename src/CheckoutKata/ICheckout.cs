namespace CheckoutKata;

public interface ICheckout
{
    decimal Total();
    void Scan(string sku, int quantity = 1);
}