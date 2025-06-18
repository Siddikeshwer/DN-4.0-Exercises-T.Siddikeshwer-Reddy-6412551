interface PaymentStrategy {
    void pay(double amount);
}

class CreditCardPayment implements PaymentStrategy {
    private String cardNumber;
    
    public CreditCardPayment(String cardNumber) {
        this.cardNumber = cardNumber;
    }
    
    @Override
    public void pay(double amount) {
        System.out.println("Paid $" + amount + " using Credit Card: " + cardNumber);
    }
}

class PayPalPayment implements PaymentStrategy {
    private String email;
    
    public PayPalPayment(String email) {
        this.email = email;
    }
    
    @Override
    public void pay(double amount) {
        System.out.println("Paid $" + amount + " using PayPal: " + email);
    }
}

class PaymentContext {
    private PaymentStrategy paymentStrategy;
    
    public void setPaymentStrategy(PaymentStrategy paymentStrategy) {
        this.paymentStrategy = paymentStrategy;
    }
    
    public void pay(double amount) {
        paymentStrategy.pay(amount);
    }
}

public class StrategyTest {
    public static void main(String[] args) {
        PaymentContext context = new PaymentContext();
        
        context.setPaymentStrategy(new CreditCardPayment("1234-5678-9012-3456"));
        context.pay(100.0);
        
        context.setPaymentStrategy(new PayPalPayment("user@example.com"));
        context.pay(200.0);
    }
}
