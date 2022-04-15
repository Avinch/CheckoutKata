namespace CheckoutKata;


public class Checkout : ICheckout
{
    private List<Item> _userBasket { get; set; }
    private List<Item> _availableItems { get; set; }
    private List<IDiscount> _availableDiscounts { get; set; }


    public Checkout()
    {
        InitItems();
    }

    private void InitItems()
    {
        _availableItems = new List<Item>();
        _userBasket = new List<Item>();
        _availableDiscounts = new List<IDiscount>();
        
        _availableItems.AddRange(new List<Item>
        {
            new("A99", 0.5m),
            new("B15", 0.3m),
            new("C40", 0.6m)
        });
        
        _availableDiscounts.AddRange(new List<IDiscount>
        {
            new MultibuyDiscount("Multibuy A99", "A99", 3, 1.3m),
            new MultibuyDiscount("Multibuy B15", "B15", 2, 0.45m)
        });
    }
    
    public decimal Total()
    {
        // we want the basket to remain intact, for example if we wanted
        // to add functionality to remove items
        var clonedBasket = _userBasket.ToList();

        foreach (var discount in _availableDiscounts)
        {
            discount.Apply(ref clonedBasket);
        }
        
        return clonedBasket.Sum(x => x.Price);
    }

    public void Scan(string sku, int quantity = 1)
    {
        var foundItem = _availableItems.SingleOrDefault(x => x.Code == sku);
        if (foundItem == null)
        {
            throw new Exception($"Item with code {sku} not found");
        }

        for (int i = 0; i < quantity; i++)
        {
            _userBasket.Add(foundItem);   
        }
    }
}

