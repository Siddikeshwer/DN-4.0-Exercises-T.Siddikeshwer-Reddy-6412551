class Logger {
    private static Logger instance;
    
    private Logger() {
    }
    
    public static Logger getInstance() {
        if (instance == null) {
            instance = new Logger();
        }
        return instance;
    }
    
    public void log(String message) {
        System.out.println(message);
    }
}

public class LoggerTest {
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();
        
        logger1.log("Logging from logger1");
        logger2.log("Logging from logger2");
        
        System.out.println("Are logger1 and logger2 the same instance? " + (logger1 == logger2));
    }
}
