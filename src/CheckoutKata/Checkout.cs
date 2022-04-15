namespace CheckoutKata;


public class Checkout : ICheckout
{
    private List<Item> _userBasket { get; set; }
    private List<Item> _availableItems { get; set; }


    public Checkout()
    {
        InitItems();
    }

    private void InitItems()
    {
        _availableItems = new List<Item>();
        _userBasket = new List<Item>();
        
        _availableItems.AddRange(new List<Item>
        {
            new("A99", 0.5m),
            new("B15", 0.3m),
            new("C40", 0.6m)
        });
    }
    
    public decimal Total()
    {
        return _userBasket.Sum(x => x.Price);
    }

    public void Scan(string sku)
    {
        var foundItem = _availableItems.SingleOrDefault(x => x.Code == sku);
        if (foundItem == null)
        {
            throw new Exception($"Item with code {sku} not found");
        }
        _userBasket.Add(foundItem);
    }
}

