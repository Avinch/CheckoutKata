namespace CheckoutKata;

public class ItemNotFoundException : Exception
{
    private readonly string _sku;

    public ItemNotFoundException(string sku)
    {
        _sku = sku;
    }

    public override string Message => $"Item with SKU {_sku} not found";
}