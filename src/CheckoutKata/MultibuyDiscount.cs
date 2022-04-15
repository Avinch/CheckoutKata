namespace CheckoutKata;

public class MultibuyDiscount : IDiscount
{
    public string Name { get; }
    public string ProductSku { get; }
    public int QuantityAppliesTo { get; }
    public decimal NewPrice { get; }


    public MultibuyDiscount(string name, string productSku, int quantityAppliesTo, decimal newPrice)
    {
        Name = name;
        ProductSku = productSku;
        QuantityAppliesTo = quantityAppliesTo;
        NewPrice = newPrice;
    }

    public void Apply(ref List<Item> items)
    {
        if (items.Any(x => x.Code == ProductSku))
        {
            var totalCount = items.Count(x => x.Code == ProductSku);

            if (totalCount < QuantityAppliesTo)
            {
                return;
            }
            
            var quantityDoesNotApplyTo = totalCount % QuantityAppliesTo;
            var totalCountAppliesTo = totalCount - quantityDoesNotApplyTo;
            var setOfDiscounts = totalCountAppliesTo / QuantityAppliesTo;

            // for each discount, add a new item with the discount price
            for (int i = 0; i < setOfDiscounts; i++)
            {
                items.Add(new Item(Name, NewPrice)
                {
                    UnderlyingDiscount = this
                });
            }

            // also take out all the items that the discount applies to
            for (int i = 0; i < totalCountAppliesTo; i++)
            {
                var matchItem = items.First(x => x.Code == ProductSku);
                items.Remove(matchItem);
            }
        }
    }
}