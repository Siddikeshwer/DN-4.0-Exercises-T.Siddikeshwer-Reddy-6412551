using System;

// Notifier.cs
public interface INotifier
{
    void Send(string message);
}

// EmailNotifier.cs
public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email notification: {message}");
    }
}

// NotifierDecorator.cs
public abstract class NotifierDecorator : INotifier
{
    protected readonly INotifier _notifier;

    public NotifierDecorator(INotifier notifier)
    {
        _notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
    }

    public virtual void Send(string message)
    {
        _notifier.Send(message);
    }
}

// SMSNotifierDecorator.cs
public class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending SMS notification: {message}");
    }
}

// SlackNotifierDecorator.cs
public class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(INotifier notifier) : base(notifier)
    {
    }

    public override void Send(string message)
    {
        base.Send(message);
        Console.WriteLine($"Sending Slack notification: {message}");
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        INotifier emailNotifier = new EmailNotifier();
        INotifier smsNotifier = new SMSNotifierDecorator(emailNotifier);
        INotifier slackNotifier = new SlackNotifierDecorator(smsNotifier);

        slackNotifier.Send("Hello, this is a notification!");
    }
}
