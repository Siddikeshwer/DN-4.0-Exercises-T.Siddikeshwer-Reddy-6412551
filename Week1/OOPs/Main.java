class Logger {
    // Private static instance, initialized eagerly
    private static final Logger instance = new Logger();

    // Private constructor to prevent instantiation
    private Logger() {
        // Prevent instantiation from outside
        if (instance != null) {
            throw new RuntimeException("Use getInstance() to get the single instance of this class.");
        }
    }

    // Public static method to get the single instance
    public static Logger getInstance() {
        return instance;
    }

    // Example logging method
    public void log(String message) {
        System.out.println("Log: " + message);
    }
}

public class Main {
    public static void main(String[] args) {
        // Get the Logger instance
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();

        // Test logging functionality
        logger1.log("Message from logger1");
        logger2.log("Message from logger2");

        // Verify both references point to the same instance
        System.out.println("Are both loggers the same instance? " + (logger1 == logger2));
        System.out.println("Logger1 hashCode: " + logger1.hashCode());
        System.out.println("Logger2 hashCode: " + logger2.hashCode());
    }
}