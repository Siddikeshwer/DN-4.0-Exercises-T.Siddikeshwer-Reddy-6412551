using System;
using System.Collections.Generic;

// IObserver.cs
public interface IObserver
{
    void Update(string stock, double price);
}

// IStock.cs
public interface IStock
{
    void RegisterObserver(IObserver observer);
    void DeregisterObserver(IObserver observer);
    void NotifyObservers();
}

// StockMarket.cs
public class StockMarket : IStock
{
    private readonly List<IObserver> _observers;
    private string _stock;
    private double _price;

    public StockMarket()
    {
        _observers = new List<IObserver>();
    }

    public void RegisterObserver(IObserver observer)
    {
        if (observer != null)
        {
            _observers.Add(observer);
        }
    }

    public void DeregisterObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_stock, _price);
        }
    }

    public void SetStockPrice(string stock, double price)
    {
        _stock = stock;
        _price = price;
        NotifyObservers();
    }
}

// MobileApp.cs
public class MobileApp : IObserver
{
    private readonly string _name;

    public MobileApp(string name)
    {
        _name = name;
    }

    public void Update(string stock, double price)
    {
        Console.WriteLine($"{_name} received update: {stock} price is now ${price}");
    }
}

// WebApp.cs
public class WebApp : IObserver
{
    private readonly string _name;

    public WebApp(string name)
    {
        _name = name;
    }

    public void Update(string stock, double price)
    {
        Console.WriteLine($"{_name} received update: {stock} price is now ${price}");
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        StockMarket stockMarket = new StockMarket();

        IObserver mobileApp = new MobileApp("MobileApp1");
        IObserver webApp = new WebApp("WebApp1");

        stockMarket.RegisterObserver(mobileApp);
        stockMarket.RegisterObserver(webApp);

        stockMarket.SetStockPrice("AAPL", 150.0);
        stockMarket.SetStockPrice("GOOG", 2700.0);
    }
}
