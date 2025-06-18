// PaymentProcessor.java
interface PaymentProcessor {
    void processPayment(double amount);
}

// PayPal.java
class PayPal {
    public void sendPayment(double amount) {
        System.out.println("Processing payment of $" + amount + " through PayPal");
    }
}

// Stripe.java
class Stripe {
    public void makePayment(double amount) {
        System.out.println("Processing payment of $" + amount + " through Stripe");
    }
}

// PayPalAdapter.java
 class PayPalAdapter implements PaymentProcessor {
    private PayPal payPal;
    
    public PayPalAdapter(PayPal payPal) {
        this.payPal = payPal;
    }
    
    @Override
    public void processPayment(double amount) {
        payPal.sendPayment(amount);
    }
}

// StripeAdapter.java
public class StripeAdapter implements PaymentProcessor {
    private Stripe stripe;
    
    public StripeAdapter(Stripe stripe) {
        this.stripe = stripe;
    }
    
    @Override
    public void processPayment(double amount) {
        stripe.makePayment(amount);
    }
}

// AdapterTest.java
class AdapterTest {
    public static void main(String[] args) {
        PaymentProcessor paypalProcessor = new PayPalAdapter(new PayPal());
        paypalProcessor.processPayment(100.0);
        
        PaymentProcessor stripeProcessor = new StripeAdapter(new Stripe());
        stripeProcessor.processPayment(200.0);
    }
}
