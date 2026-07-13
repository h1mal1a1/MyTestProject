namespace MyTestProject.Patterns.StructuralPatterns.Decorator;

public class LoggingNotifierDecorator(INotifier notifier) : INotifier
{
    private readonly INotifier _notifier = notifier;

    public void Send(string message)
    {
        Console.WriteLine($"Before sending notification");
        _notifier.Send(message);
        Console.WriteLine($"After sending notification");
    }
}