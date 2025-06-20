using System;

// PaymentProcessor.cs
public interface IPaymentProcessor {
    void ProcessPayment(double amount);
}

// PayPal.cs
public class PayPal {
    public void SendPayment(double amount) {
        Console.WriteLine($"Processing payment of ${amount} through PayPal");
    }
}

// Stripe.cs
public class Stripe {
    public void MakePayment(double amount) {
        Console.WriteLine($"Processing payment of ${amount} through Stripe");
    }
}

// PayPalAdapter.cs
public class PayPalAdapter : IPaymentProcessor {
    private readonly PayPal _payPal;

    public PayPalAdapter(PayPal payPal) {
        _payPal = payPal;
    }

    public void ProcessPayment(double amount) {
        _payPal.SendPayment(amount);
    }
}

// StripeAdapter.cs
public class StripeAdapter : IPaymentProcessor {
    private readonly Stripe _stripe;

    public StripeAdapter(Stripe stripe) {
        _stripe = stripe;
    }

    public void ProcessPayment(double amount) {
        _stripe.MakePayment(amount);
    }
}

// Program.cs
public class Program {
    public static void Main(string[] args) {
        IPaymentProcessor paypalProcessor = new PayPalAdapter(new PayPal());
        paypalProcessor.ProcessPayment(100.0);

        IPaymentProcessor stripeProcessor = new StripeAdapter(new Stripe());
        stripeProcessor.ProcessPayment(200.0);
    }
}
