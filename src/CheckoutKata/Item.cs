namespace CheckoutKata;

public class Item
{
    public string Code { get; }
    public decimal Price { get; }

    public Item(string code, decimal price)
    {
        Code = code;
        Price = price;
    }
}