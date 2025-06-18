
// StockMarket.java
import java.util.ArrayList;
import java.util.List;

class StockMarket implements Stock {
    private List<Observer> observers;
    private String stock;
    private double price;
    
    public StockMarket() {
        observers = new ArrayList<>();
    }
    
    @Override
    public void registerObserver(Observer observer) {
        observers.add(observer);
    }
    
    @Override
    public void deregisterObserver(Observer observer) {
        observers.remove(observer);
    }
    
    @Override
    public void notifyObservers() {
        for (Observer observer : observers) {
            observer.update(stock, price);
        }
    }
    
    public void setStockPrice(String stock, double price) {
        this.stock = stock;
        this.price = price;
        notifyObservers();
    }
}

// MobileApp.java
public class MobileApp implements Observer {
    private String name;
    
    public MobileApp(String name) {
        this.name = name;
    }
    
    @Override
    public void update(String stock, double price) {
        System.out.println(name + " received update: " + stock + " price is now $" + price);
    }
}

// WebApp.java
class WebApp implements Observer {
    private String name;
    
    public WebApp(String name) {
        this.name = name;
    }
    
    @Override
    public void update(String stock, double price) {
        System.out.println(name + " received update: " + stock + " price is now $" + price);
    }
}

// ObserverTest.java
class ObserverTest {
    public static void main(String[] args) {
        StockMarket stockMarket = new StockMarket();
        
        Observer mobileApp = new MobileApp("MobileApp1");
        Observer webApp = new WebApp("WebApp1");
        
        stockMarket.registerObserver(mobileApp);
        stockMarket.registerObserver(webApp);
        
        stockMarket.setStockPrice("AAPL", 150.0);
        stockMarket.setStockPrice("GOOG", 2700.0);
    }
}

// Observer.java
interface Observer {
    void update(String stock, double price);
}
interface Stock {
    void registerObserver(Observer observer);
    void deregisterObserver(Observer observer);
    void notifyObservers();
}