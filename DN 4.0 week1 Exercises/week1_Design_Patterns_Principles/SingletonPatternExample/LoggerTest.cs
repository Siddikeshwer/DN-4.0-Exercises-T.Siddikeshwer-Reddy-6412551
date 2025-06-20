using System;

// Logger.cs
public class Logger
{
    private static Logger _instance;

    // Private constructor to prevent instantiation
    private Logger()
    {
    }

    // Thread-safe singleton implementation
    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("Logging from logger1");
        logger2.Log("Logging from logger2");

        Console.WriteLine($"Are logger1 and logger2 the same instance? {ReferenceEquals(logger1, logger2)}");
    }
}
