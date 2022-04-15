namespace CheckoutKata;

public interface IDiscount
{
    string Name { get; }
    void Apply(ref List<Item> items);
}