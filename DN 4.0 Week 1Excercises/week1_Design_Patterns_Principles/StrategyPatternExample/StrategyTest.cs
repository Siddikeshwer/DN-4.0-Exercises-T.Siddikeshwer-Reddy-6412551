using System;

// IPaymentStrategy.cs
public interface IPaymentStrategy
{
    void Pay(double amount);
}

// CreditCardPayment.cs
public class CreditCardPayment : IPaymentStrategy
{
    private readonly string _cardNumber;

    public CreditCardPayment(string cardNumber)
    {
        _cardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Paid ${amount} using Credit Card: {_cardNumber}");
    }
}

// PayPalPayment.cs
public class PayPalPayment : IPaymentStrategy
{
    private readonly string _email;

    public PayPalPayment(string email)
    {
        _email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Paid ${amount} using PayPal: {_email}");
    }
}

// PaymentContext.cs
public class PaymentContext
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        _paymentStrategy = paymentStrategy ?? throw new ArgumentNullException(nameof(paymentStrategy));
    }

    public void Pay(double amount)
    {
        _paymentStrategy.Pay(amount);
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        PaymentContext context = new PaymentContext();

        context.SetPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456"));
        context.Pay(100.0);

        context.SetPaymentStrategy(new PayPalPayment("user@example.com"));
        context.Pay(200.0);
    }
}
