namespace MyTestProject.Patterns.StructuralPatterns.Decorator;

public class RetryNotifierDecorator(INotifier notifier) : INotifier
{
    private readonly INotifier _notifier = notifier;

    public void Send(string message)
    {
        try
        {
            _notifier.Send(message);
        }
        catch
        {
            Console.WriteLine($"Retry sending notification");
            _notifier.Send(message);
        }
    }
}