namespace MyTestProject.Patterns.StructuralPatterns.Decorator;

public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email notification: {message}");
    }
}