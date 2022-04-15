using NUnit.Framework;

namespace CheckoutKata.Tests;

public class MultibuyDiscountTests
{
    private ICheckout _checkout;
    
    [SetUp]
    public void Setup()
    {
        _checkout = new Checkout();
    }
    
    [TearDown]
    public void Teardown()
    {
        _checkout = null;
    }
    
    [Test]
    public void MultibuyDiscount_TotalMatches_Test1()
    {
        _checkout.Scan("B15",2);
        var total = _checkout.Total();
        Assert.AreEqual(0.45m, total);
    }
    
    [Test]
    public void MultibuyDiscount_TotalMatches_Test2()
    {
        _checkout.Scan("A99",3);
        var total = _checkout.Total();
        Assert.AreEqual(1.3m, total);
    }
    
    [Test]
    public void MultibuyDiscount_Uneven_TotalMatches_Test1()
    {
        _checkout.Scan("B15",3);
        var total = _checkout.Total();
        Assert.AreEqual(0.75m, total);
    }
    
    [Test]
    public void MultibuyDiscount_Uneven_TotalMatches_Test2()
    {
        _checkout.Scan("A99",5);
        var total = _checkout.Total();
        Assert.AreEqual(2.3m, total);
    }
    
    [Test]
    public void MultibuyDiscount_MultipleDiscount_TotalMatches_Test1()
    {
        _checkout.Scan("A99",9);
        var total = _checkout.Total();
        Assert.AreEqual(3.9m, total);
    }

    [Test]
    public void MultibuyDiscount_VariedDiscounts_TotalMatches_Test1()
    {
        _checkout.Scan("A99",3);
        _checkout.Scan("B15",2);
        var total = _checkout.Total();
        Assert.AreEqual(1.75m, total);
    }
}