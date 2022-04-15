using System;
using NUnit.Framework;

namespace CheckoutKata.Tests;

public class CheckoutTests
{
    private ICheckout _checkout;
    
    [SetUp]
    public void Setup()
    {
        _checkout = new Checkout();
    }

    [Test]
    public void SingleQuantityItems_TotalMatches_Test1()
    {
        _checkout.Scan("A99");
        _checkout.Scan("B15");
        _checkout.Scan("C40");
        var total = _checkout.Total();
        Assert.AreEqual(1.4m, total);
    }
    
    [Test]
    public void SingleQuantityItems_TotalMatches_Test2()
    {
        _checkout.Scan("A99");
        _checkout.Scan("C40");
        var total = _checkout.Total();
        Assert.AreEqual(1.1m, total);
    }
    
    [Test]
    public void SingleQuantityItems_TotalMatches_Test3()
    {
        _checkout.Scan("B15");
        _checkout.Scan("C40");
        var total = _checkout.Total();
        Assert.AreEqual(0.9m, total);
    }
    
    [Test]
    public void NonExistentItem_ThrowsException()
    {
        Assert.Throws<ItemNotFoundException>(() => _checkout.Scan("code_does_not_exist"));
    }

    [TearDown]
    public void Teardown()
    {
        _checkout = null;
    }
}